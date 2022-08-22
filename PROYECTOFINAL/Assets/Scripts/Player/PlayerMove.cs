using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
      [SerializeField]
    [Range(1f, 10f)]
    private float speed = 3f;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.back);
        }
        
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

   
}
