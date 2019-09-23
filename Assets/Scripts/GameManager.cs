using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public GameObject Painel;
    public GameObject game_over;
    public Text finalScore;
    public Text textPause;
    public Text lives;
    public Text textCoins;

    public bool gameOverBool = false;
    public bool isPaused = false;


    // Start is called before the first frame update
    void Start(){ }

    // Update is called once per frame
    void Update(){
        gameOver();
    }

    public void Pause(){
        if (isPaused){
            Time.timeScale = 1;
            Painel.SetActive(false);
            isPaused = false;
            textPause.text = "Pause";
        }
        else{
            Time.timeScale = 0;
            Painel.SetActive(true);
            isPaused = true;
            textPause.text = "Resume";
        }
    }

    public void gameOver(){
        if (Convert.ToInt32(lives.text) <= 0){
            game_over.SetActive(true);
            finalScore.text = "Score: " + textCoins.text;
            Time.timeScale = 0;
        }
        else{
            game_over.SetActive(false);
        }
    }
}