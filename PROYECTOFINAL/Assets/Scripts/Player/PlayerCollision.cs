using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    private PlayerData playerData;
    private PlayerMove playerMove;

    private PlayerJump playerJump;

    private bool gameOverMessage = false;

    private float timer = 0f;

    private void Start() {
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
    }

    private void Update() {       
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("ENTRANDO EN COLISION CON ->" + other.gameObject.name); 

        switch (other.gameObject.tag){
            case "Cat": SavedACatMessage(other);
            break;
            case "Star": ExtraLife(other);
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

    private void ExtraLife(Collision other){

        Destroy(other.gameObject);
        if (playerData.Lifes > 0 && playerData.Lifes < 5) 
            playerData.PowerUp();
    }
}
