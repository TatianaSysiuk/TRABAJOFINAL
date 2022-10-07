using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour {

    private float waitTime = 0.75f;

    void Start(){
        Debug.Log("CARGANDO ESCENA");
    }

    public void OnClickPlay(){
        
        Debug.Log("SE PRESIONO EL BOTON PLAY");

        StartCoroutine(WaitForGame(waitTime));
        StopCoroutine(WaitForGame(0));
    }

    IEnumerator WaitForGame(float time){ 
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }

}
