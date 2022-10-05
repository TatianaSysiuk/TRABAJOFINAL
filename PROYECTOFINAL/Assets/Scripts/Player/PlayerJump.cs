using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public Rigidbody rb;
    public float FuerzaDeSalto = 8f;
    public bool puedoSaltar;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space)){

                anim.SetBool("SALTE", true);
                rb.AddForce(new Vector3(0,FuerzaDeSalto,0),ForceMode.Impulse);

            }
            anim.SetBool("TOCARSUELO",true);
        }
        else{
            EstoyCayendo();
        }
    }

    public void EstoyCayendo(){
        anim.SetBool("TOCARSUELO", false);
        anim.SetBool("SALTE", false);
    }
}
