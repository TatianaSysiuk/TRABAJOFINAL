using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPies : MonoBehaviour {
    public PlayerJump playerJump;

    private void OnTriggerStay(Collider other) {
        playerJump.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other) {
        
     playerJump.puedoSaltar = false;
    }
}

