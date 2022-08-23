using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("ENTRANDO EN COLISION CON ->" + other.gameObject.name);
     
    }
}
