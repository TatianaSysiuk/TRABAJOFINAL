using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
/*
    public Rigidbody rb;
    public float FuerzaDeSalto = 8f;
    public int cantSaltos = 0;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {


    }

    // Update is called once per frame
    void Update()
    {

             Salto();
           //if (Input.GetKeyDown(KeyCode.Space)){

                //anim.SetBool("SALTE", true);
               // rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);


            //}
           // anim.SetBool("TOCARSUELO",true);


    }
     public void Salto() {
        if ( Input.GetKeyDown(KeyCode.Space) && (cantSaltos + 1) <= 2 )
        { 
            
        
                 playerAnimator.SetTrigger("FORWARD");
                cantSaltos++;
               
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);
                anim.SetBool("TOCARSUELO",true);
                if(cantSaltos == 2)
                {
                    StartCoroutine(stopJump());
                }
        }

    }
    IEnumerator stopJump() {
yield return new WaitForSeconds(3f);
    cantSaltos = 0;
    }*/
}
