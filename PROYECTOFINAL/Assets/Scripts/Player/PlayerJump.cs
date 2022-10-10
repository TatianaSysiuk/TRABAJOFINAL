using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    public Rigidbody rb;
    [SerializeField] private float FuerzaDeSalto = 15f;
    public bool puedoSaltar;

    private Animator anim;

    // Start is called before the first frame update
    void Start(){
        
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
        
           if (puedoSaltar && Input.GetKeyDown(KeyCode.Space)){

                anim.SetBool("SALTE", true);
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);
                

            }
            anim.SetBool("TOCARSUELO",true);
    
    
    }
    public void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("piso"))
        {
             if (puedoSaltar && Input.GetKeyDown(KeyCode.Space)){

                anim.SetBool("SALTE", true);
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);
                

            }
            anim.SetBool("TOCARSUELO",true);
        }
        
    }

    
    
}
