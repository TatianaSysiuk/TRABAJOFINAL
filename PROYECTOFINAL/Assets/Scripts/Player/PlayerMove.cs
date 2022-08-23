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


    private bool applyGravity = false;
    private Vector3 playerDirection;

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

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            playerDirection += Vector3.up * 50;
        }

        if (applyGravity) playerDirection += Vector3.down;
        if (transform.position.y <= 0 && canJump) applyGravity = false;

        if (!canJump)
        {
            if (transform.position.y <= JumpHeight)
            {
                playerDirection += Vector3.up;
            }
            else
            {
                applyGravity = true;
            }

        }
    }

        void MovePlayer(Vector3 direction)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
}
