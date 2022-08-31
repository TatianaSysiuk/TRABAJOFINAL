using System.Collections;
using UnityEngine;

public class platformController : MonoBehaviour {
    
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    
    [SerializeField] [Range(2f,8f)] private float platformSpeed = 6f;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveNext = true;
    [SerializeField] [Range(1f,10f)] private float waitTime = 1f;

    private void Update() {
        Move();
    }

    private void Move(){

        if (moveNext){
            StopCoroutine(WaitForMove(0));
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }
    
    
        if (Vector3.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0){
            
            StartCoroutine(WaitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition++;

            if (nextPosition > platformPositions.Length - 1)
                nextPosition = 0;
        }
    }

    IEnumerator WaitForMove(float time){
        moveNext = false;
        yield return new WaitForSeconds(time);
        moveNext = true;
    }
}
