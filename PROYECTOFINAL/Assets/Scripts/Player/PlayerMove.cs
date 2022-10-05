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

    [SerializeField] private int JumpHeight = 4;


    
    private Vector3 playerDirection;

    [SerializeField] Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.forward);
            if (!IsAnimation("FORWARD")) playerAnimator.SetTrigger("FORWARD");
            

        }


        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.back); 
            if (!IsAnimation("BACK")) playerAnimator.SetTrigger("BACK");
            

        }


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
