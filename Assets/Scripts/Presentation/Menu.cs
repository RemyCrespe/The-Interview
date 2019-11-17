using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void PlayButton()
    {
        GameManager.Instance.LoadNextLevel();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Game Started !");
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();

        // Application.Quit();
        // print("Jeu quitté !");
    }
}
