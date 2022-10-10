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
     public Rigidbody rb;
    public float FuerzaDeSalto = 8f;
    public int cantSaltos = 0;

    private Animator anim;

    // Update is called once per frame
    void Update(){
        Movement();      
        Salto();
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

       /* if (Input.GetKeyDown(KeyCode.Space) && canJump){
            canJump = false;
            playerDirection += Vector3.up * 50;
        }*/
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
      public void Salto() {
        if ( Input.GetKeyDown(KeyCode.Space) && (cantSaltos + 1) <= 2 )
        { 
            
        
               //  playerAnimator.SetTrigger("JUMP");
                cantSaltos++;
                playerAnimator.SetBool("JUMP",true);
              // playerAnimator.SetTrigger("JUMP");
        
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);
                StartCoroutine(stopAnimJump());
                if(cantSaltos == 2)
                {
                    StartCoroutine(stopJump());
                }
        }

    }
    IEnumerator stopJump() {
yield return new WaitForSeconds(3f);
    cantSaltos = 0;
    }
    IEnumerator stopAnimJump() {
        yield return new WaitForSeconds(1f);
        playerAnimator.SetBool("JUMP",false);

    }
}
