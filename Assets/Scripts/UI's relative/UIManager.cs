using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] MainMenu _mainMenu;
    [SerializeField] Camera _dummyCamera;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _playerUI;
    // public string defaultScene; // Scene chargée par défaut
    [SerializeField] GameObject _endGamePanel;
    [SerializeField] Text _endGameText;
    [SerializeField] Button _nextLevelButton;
    private Image panelBackground;


    public void Start()
    {
        panelBackground = _endGamePanel.GetComponent<Image>(); // Récupère l'arrière plan du panneau
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && 
            !_mainMenu.isActiveAndEnabled && 
            !GameManager.Instance.IsIntroductionLevel())
        {
            PauseGame();
        }
    }


    public void SetDummyCameraActive(bool active)
    {
        _dummyCamera.gameObject.SetActive(active);
    }


    public void StartGame(string sceneToLoad)
    {
        GameManager.Instance.LoadLevel(sceneToLoad);
        _mainMenu.gameObject.SetActive(false);
        SetDummyCameraActive(false);
    }

    public void LoadSelectedLevel(int number)
    {
        GameManager.Instance.LoadSelectedLevel(number);
    }

    public void LoadNextLevelButton()
    {
        ResetUI();
        GameManager.Instance.LoadNextLevel();
    }


    // Menu Pause
    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            EnablePlayerUI(false);
            _pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0; // Met l'échelle de temps à 0
        }

        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            _pauseMenu.gameObject.SetActive(false);
            EnablePlayerUI(true);
        }

    }


    // Gestion de la fin du jeu
    public void EndGame(bool isWinning) // Menu de fin de jeu
    {
        if (isWinning) // Si victoire
        {
            // Couleur de l'arrière plan (bleu pour la victoire)
            panelBackground.color = new Color(0.2f , 0.45f, 0.49f, 0.6f); // Couleur en ARGB = 170, 50, 111, 124

            // Texte affiché
            _endGameText.text = "Congratulation, let's continue testing !";

            // Ativation du boutton de passage de niveau si un prochain niveau est dispo
            if (GameManager.Instance.IsLastLevel)
            {
                _nextLevelButton.interactable = false;
                _endGameText.text = "Nice job, you will begin on next Monday !";
            }
            else
                _nextLevelButton.interactable = true;

            // Activation de l'interface
            _endGamePanel.SetActive(true);

        }
        else // Si défaite
        {
            // Couleur de l'arrière plan (rouge pour la défaite)
            panelBackground.color = new Color(0.8f, 0.2f, 0.2f, 0.6f); // Couleur en ARGB = 170, 200, 50, 50

            // Texte affiché
            _endGameText.text = "Sorry but you're not qualified for this job.";

            // Désativation du boutton de passage de niveau
            _nextLevelButton.interactable = false;

            // Activation de l'interface
            _endGamePanel.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void EnablePlayerUI(bool enable)
    {
        _playerUI.gameObject.SetActive(enable);
    }

    private void ResetUI()
    {
        _pauseMenu.gameObject.SetActive(false);
        _endGamePanel.gameObject.SetActive(false);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        GameManager.Instance.MainMenuReturn();
    }

    public void RestartButton()
    {
        ResetUI();
        GameManager.Instance.RestartGame();
    }

    public void QuitButton()
    {
        GameManager.Instance.QuitGame();
    }

}
