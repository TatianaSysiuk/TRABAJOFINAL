using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public Rigidbody rb;
    public float FuerzaDeSalto = 8f;
    public bool puedoSaltar;

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
        
        
           if (Input.GetKeyDown(KeyCode.Space)){

                anim.SetBool("SALTE", true);
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);
                

            }
            anim.SetBool("TOCARSUELO",true);
    
    
    }
    public void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("piso"))
        {
             if (Input.GetKeyDown(KeyCode.Space)){

                anim.SetBool("SALTE", true);
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);
                

            }
            anim.SetBool("TOCARSUELO",true);
        }
        
    }

    
    
}
