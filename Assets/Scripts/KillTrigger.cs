using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour {
    void Start() {
            
    }

    void Update() {
        
    }

    private void onTriggerEnter2D(Collider2D collision) {
        // if (collision.tag == "Player") {
        if (collision.CompareTag("Player")) {
            if(GameManager.sharedInstance.currentGameState != GameState.gameOver)
            {
                PlayerController.sharedInstance.Kill();
            }
        }
    }
}
