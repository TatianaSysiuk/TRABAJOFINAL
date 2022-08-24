using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireData : MonoBehaviour {
    [SerializeField] [Range(5, 10)] private int damagePoints = 5;
    public int DamagePoints { get { return damagePoints; } }

}
