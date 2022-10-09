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

        switch (other.gameObject.tag){  //HACER UN IF
            case "Cat": SavedACatMessage(other);    //suma 500 puntos
            break;
            case "Water":   PlayerEvents.OnHealCall(other.gameObject.GetComponent<WaterData>().HealPoints);
                            PlayerCollision.OnChangeHP?.Invoke(playerData.LifePoints);
                            Destroy(other.gameObject);
                            Debug.Log(playerData.LifePoints);
                            GameEvents.OnScoreCall(GameManager.Score);
                            PlayerCollision.OnChangeScore?.Invoke(300); 
            break;
            case "Star": //suma 200 puntos del juego en el game manager
            break;
            case "Platform": playerJump.puedoSaltar = false;
            break;
            default:
            break;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("ENTRANDO EN EL TRIGGER ->" + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other) {
                
        if (other.gameObject.CompareTag("Fire")){
            
            if (playerData.LifePoints > 0){
                if (timer >= 1.5f){
                    playerData.Damage(other.gameObject.GetComponent<FireData>().DamagePoints);
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

    private void SavedACatMessage(Collision other){
        Debug.Log("Gatito salvado!");
        if (playerData.CatsToSave > 0){
            playerData.SaveACat();
            Destroy(other.gameObject);
        }
        Debug.Log("Gatitos a salvar restantes: " + playerData.CatsToSave);
    }

}
