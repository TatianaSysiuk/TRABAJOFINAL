using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterData : MonoBehaviour{

    [SerializeField][Range(1, 200)] private int healPoints = 100;
    public int HealPoints { get { return healPoints; } }

}
