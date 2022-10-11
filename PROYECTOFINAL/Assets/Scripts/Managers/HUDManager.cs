using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour{

    private static HUDManager instance;
    public static HUDManager Instance { get => instance; }

    [SerializeField] private Slider hpBar;

    [SerializeField] private Slider scoreBar;

    private PlayerData playerData;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    // Start is called before the first frame update
 
    private void Awake(){
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null){
            instance = this;
            Debug.Log(instance);

            PlayerCollision.OnDead += GameOver;
            PlayerCollision.OnWin += WinGame;
            PlayerCollision.OnChangeHP += SetHPBar;
            GameEvents.OnScore += SetScoreBar;
        }
        else      
            Destroy(gameObject);      
    }

    public static void SetHPBar(int newValue){

        instance.hpBar.value = newValue;
        Debug.Log("new value: " + newValue + "total: " + instance.hpBar.value);
    }

    public static void SetScoreBar(int newValue){

        instance.scoreBar.value = newValue;
        Debug.Log("new value: "+ newValue + "valor en la barra: " + instance.scoreBar.value);
    }

    private void GameOver(){

        Debug.Log("RESPUESTA DESDE OTRO SCRIPT");
        gameOverPanel.SetActive(true);
    }

    private void WinGame(){
        winPanel.SetActive(true);
    }
    
    private void OnDisable(){

        PlayerCollision.OnDead -= GameOver;
        PlayerCollision.OnChangeHP -= SetHPBar;
        GameEvents.OnScore -= SetScoreBar;
    }
}
