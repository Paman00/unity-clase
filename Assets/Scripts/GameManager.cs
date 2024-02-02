using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    menu,
    inGame,
    gameOver 
}

public class GameManager : MonoBehaviour {
    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.menu;

    void Start() {
        StartGame();
    }

    private void Awake() {
        sharedInstance = this;
    }

    void Update() {
        
    }

    public void setGameState(GameState newGameState) {
        if (newGameState == GameState.menu) {
            // Estoy en menú
        } else if (newGameState == GameState.inGame) {
            // Estoy en juego
        } else {
            // Estoy en game over
        }
        this.currentGameState = newGameState;
    }

    public void StartGame() {
        setGameState(GameState.inGame);
    }

    public void BackToMenu() {
        setGameState(GameState.menu);
    }

    public void GameOver() {
        setGameState(GameState.gameOver);
    }
}
