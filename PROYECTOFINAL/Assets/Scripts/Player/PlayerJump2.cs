using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump2 : MonoBehaviour
{
    public float Jumpv = 0.4f;
    public Rigidbody rb;
    public float thrust = 10;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    public void Jump(){
        rb.AddForce(0, thrust, 0, ForceMode.Impulse);
    }
}
