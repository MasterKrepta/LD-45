using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject howTo;
    [SerializeField] GameObject Restart;

    void OnEnable() {
        Events.OnPlayerDied += ShowRestartButton;
        Events.OnGameOver += ShowWinScreen;
    }

    void OnDisable() {
        Events.OnPlayerDied -= ShowRestartButton;
        Events.OnGameOver -= ShowWinScreen;
    }


  

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void HowToPlay() {
        
        howTo.SetActive(!howTo.activeInHierarchy);
        
    }

    void ShowRestartButton() {
        Restart.SetActive(true);
    }

    void ShowWinScreen() {
        SceneManager.LoadScene(2);
    }

    
}
