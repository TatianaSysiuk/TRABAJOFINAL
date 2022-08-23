using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    
    [SerializeField] GameObject target;

    private void LateUpdate(){  //se ejecuta después de que el player esté posicionado
        transform.position = target.transform.position;
    }
}
