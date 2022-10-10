using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    private static int score = 0;
    public static int Score { get => score; set => score = value; }
    
    public static bool GameOver = false;

    private void Awake(){

        if (instance == null){   
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            PlayerCollision.OnChangeScore += SetScore;
        }else
            Destroy(gameObject);     
    }

    public static void SetScore(int newValue){

        score += newValue;
        Debug.Log("nuevo valor: " + newValue + "DESDE EL Game Manager "+ score);
    }

    private void OnDisable(){

        PlayerCollision.OnChangeScore -= SetScore;
    }
}
