using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour{

    private PlayerData playerData;
    private PlayerMove playerMove;

    private bool gameOverMessage = false;

    private float timer = 0f;

    private void Start() {
        playerData = GetComponent<PlayerData>();
        playerMove = GetComponent<PlayerMove>();
    }

    private void Update() {       
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("ENTRANDO EN COLISION CON ->" + other.gameObject.name); 

        switch(other.gameObject.tag){
            case "Floor": playerMove.CanJump = true;
            break;
            case "Cat": SavedACatMessage(other);
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
        Debug.Log("Gatito salvado!");   //estos mensajes por consola son porque no sabemos usar interfaces aún
        if (playerData.CatsToSave > 0){
            playerData.SaveACat();
            Destroy(other.gameObject);
        }
        Debug.Log("Gatitos a salvar restantes: " + playerData.CatsToSave);
    }
}
