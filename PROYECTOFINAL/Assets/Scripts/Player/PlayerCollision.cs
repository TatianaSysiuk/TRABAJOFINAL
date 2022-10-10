using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour{

    private PlayerData playerData;
    private PlayerMove playerMove;

    private PlayerJump playerJump;

    private bool gameOverMessage = false;

    private float timer = 0f;

    [SerializeField] private Transform entryTransform;

//---------------EVENTOS--------------------
    public static event Action OnDead;
    public static event Action<int> OnChangeHP;

    public static event Action<int> OnChangeScore;

    private void Start() {
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();

        PlayerCollision.OnChangeHP?.Invoke(playerData.LifePoints);
        PlayerCollision.OnChangeScore?.Invoke(GameManager.Score);
    }

    private void Update() {       
        
        timer += Time.deltaTime;
        if (GameManager.GameOver == false){

            if (playerData.LifePoints <= 0){
                PlayerCollision.OnDead?.Invoke();
                
                Debug.Log("GAME OVER -- SIN VIDA");
                GameManager.GameOver = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("ENTRANDO EN COLISION CON ->" + other.gameObject.name); 
        //Debug.Log("tag: " + other.gameObject.tag);

        switch (other.gameObject.tag){  
            case "Cat": SavedACatMessage(other);    //suma 300 puntos
            break;
            case "Water": MoreWaterForTheFirefighter(other);
            break;
            case "Star": StarReached(other);//suma 200 puntos del juego en el game manager
            break;
           
            default:
            break;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("ENTRANDO EN EL TRIGGER ->" + other.gameObject.name);

        if (other.gameObject.CompareTag("Portal"))
            transform.Translate(entryTransform.position.x,entryTransform.position.y,entryTransform.position.z);
        
    }

    private void OnTriggerStay(Collider other) {
                
        if (other.gameObject.CompareTag("Fire")){
            
            if (playerData.LifePoints > 0){
                if (timer >= 1.5f){
                    PlayerEvents.OnDamageCall(other.gameObject.GetComponent<FireData>().DamagePoints);
                    PlayerCollision.OnChangeHP?.Invoke(playerData.LifePoints);
                    
                    Debug.Log("New Life Points: " + playerData.LifePoints);
                    timer = 0;
                }
            }
            else{

                if (gameOverMessage == false){
                    Debug.Log("GAME OVER");
                    gameOverMessage = true;
                    playerData.GameOverPosition();
                }
            }     
        }
    }

    private void SavedACatMessage(Collision other){ //add 300 score points

        Debug.Log("Gatito salvado!");
        
        if (playerData.CatsToSave > 0){
            playerData.SaveACat();
        
            PlayerCollision.OnChangeScore?.Invoke(300);
            if (GameManager.Score == 0)
                GameEvents.OnScoreCall(300);
            else
                GameEvents.OnScoreCall(GameManager.Score);

            
            Destroy(other.gameObject);
            Debug.Log("game score: " + GameManager.Score);
        }
        Debug.Log("Gatitos a salvar restantes: " + playerData.CatsToSave);
    }

    private void MoreWaterForTheFirefighter(Collision other){   //add 100 score points

        PlayerEvents.OnHealCall(other.gameObject.GetComponent<WaterData>().HealPoints);
        PlayerCollision.OnChangeHP?.Invoke(playerData.LifePoints);
    
        Debug.Log("lifepoints: " + playerData.LifePoints);

        PlayerCollision.OnChangeScore?.Invoke(100); 
        if (GameManager.Score == 0)
            GameEvents.OnScoreCall(100);
        else
            GameEvents.OnScoreCall(GameManager.Score);                  
        
        Destroy(other.gameObject);
        Debug.Log("game score: " + GameManager.Score);
    }

    private void StarReached(Collision other){  

        /*when the player reaches a star, he will 
        teleport to a random position inside the building*/

        //poner posicion en relacion al building
        transform.Translate(0,UnityEngine.Random.Range(-52.8f,10f),UnityEngine.Random.Range(26.8f,32.1f));
        
        PlayerCollision.OnChangeScore?.Invoke(200);
        if (GameManager.Score == 0)
            GameEvents.OnScoreCall(200);
        else
            GameEvents.OnScoreCall(GameManager.Score);
        
        
        Destroy(other.gameObject);

        Debug.Log("star reached, points: " + GameManager.Score);
    }

}
