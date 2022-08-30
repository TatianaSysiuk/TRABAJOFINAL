using System.Collections;
using UnityEngine;

public class platformController : MonoBehaviour {
    
    public Rigidbody platformRB;
    public Transform[] platformPositions;
    
    [SerializeField] [Range(0.2f,5f)] private float platformSpeed = 1f;

    private int actualPosition = 0;
    private int nextPosition = 1;

    public bool moveNext = true;
    public float waitTime;

    private void Update() {
        Move();
    }

    private void Move(){

        if (moveNext){
            StopCoroutine(WaitForMove(0));
            platformRB.MovePosition(Vector3.MoveTowards(platformRB.position, platformPositions[nextPosition].position, platformSpeed * Time.deltaTime));
        }
    
    
        if (Vector3.Distance(platformRB.position, platformPositions[nextPosition].position) <= 0){
            
            StopCoroutine(WaitForMove(waitTime));
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
