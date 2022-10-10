using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 3f;

    private bool canJump = true;
    public bool CanJump { get => canJump; set => canJump = value; }
  
    private Vector3 playerDirection;

    [SerializeField] Animator playerAnimator;

    // Update is called once per frame
    void Update(){
        Movement();      
    }

    private void Movement(){
        
        if (Input.GetKey(KeyCode.D)){
            MovePlayer(Vector3.forward);
            if (!IsAnimation("FORWARD")) playerAnimator.SetTrigger("FORWARD");
        }


        if (Input.GetKey(KeyCode.A)){
            MovePlayer(Vector3.back); 
            if (!IsAnimation("BACK")) playerAnimator.SetTrigger("BACK");
            
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            if (!IsAnimation("IDLE")) playerAnimator.SetTrigger("IDLE");

        if (Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            playerDirection += Vector3.up * 50;
        }
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
