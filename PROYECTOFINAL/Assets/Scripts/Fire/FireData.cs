using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireData : MonoBehaviour {
    [SerializeField] [Range(10, 20)] private int damagePoints = 15;
    public int DamagePoints { get { return damagePoints; } }

}
