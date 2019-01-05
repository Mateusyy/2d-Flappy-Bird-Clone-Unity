using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool isGame;
    public bool waitForRestart;

    public Text mainInfoText;

    private void Start() {
        isGame = false;
        waitForRestart = false;

        mainInfoText.gameObject.SetActive(true);
        mainInfoText.text = "Tap to start!";
    }

    private void Update() {
        
    }

    public void StartGame() {
        isGame = true;
        mainInfoText.gameObject.SetActive(false);
    }

    public void EndGame() {
        isGame = false;
        mainInfoText.text = "Tap to restart!";
        mainInfoText.gameObject.SetActive(true);
        waitForRestart = true;
    }
}
