using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    [SerializeField] private int lifePoints = 1000;
    public int LifePoints { get { return lifePoints; } }

    private int catsToSave = 4;
    public int CatsToSave { get { return catsToSave; } }

    private PlayerMove playerMovement;
    public PlayerMove PlayerMovement { get { return playerMovement; } }

    private void Start() {
       playerMovement = GetComponent<PlayerMove>();
       playerMovement.enabled = true;
    }

    private void OnEnable(){
        PlayerEvents.OnHeal += PowerUp;
        PlayerEvents.OnDamage += Damage;
    }

    private void OnDisable(){
        PlayerEvents.OnHeal -= PowerUp;
        PlayerEvents.OnDamage -= Damage;
    }

    public void Damage(int value){
        lifePoints -= value;
    }

    public void SaveACat(){
        catsToSave--;
    }

    public void PowerUp(int healPoints){ //healing

        lifePoints += healPoints;
        Debug.Log("Life Points: " + LifePoints);
    }

    public void GameOverPosition(){
        playerMovement.enabled = false;
    }
}
