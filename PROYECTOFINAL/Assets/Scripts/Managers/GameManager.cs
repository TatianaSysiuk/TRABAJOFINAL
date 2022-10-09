using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    private static int score = 100;
    public static int Score { get => score; set => score = value; }
    
    public static bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake(){

        if (instance == null){   
            instance = this;
            score = 0;
            DontDestroyOnLoad(gameObject);
        }else
            Destroy(gameObject);     
    }
}
