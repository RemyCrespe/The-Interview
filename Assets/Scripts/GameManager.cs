using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public string[] scenesNames;
    public GameObject[] SystemPrefabs;
    private bool isLastLevel;
    private List<GameObject> _instanciedSystemPrefabs;

    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;


    public void Start()
    {
        _instanciedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

        _loadOperations = new List<AsyncOperation>();
    }

    public void Update()
    {
        if (_currentLevelName == scenesNames[scenesNames.Length - 1]) // Fait en sorte que le bouton "Next level" soit grisé lors du dernier niveau
        {
            isLastLevel = true;
            Debug.Log("That level is the ultimate !");
        }
    }


    public void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instanciedSystemPrefabs.Add(prefabInstance);
        }
    }


    protected override void OnDestroy()
    {
        for (int i = 0; i < _instanciedSystemPrefabs.Count; ++i) // Détruit les GameObjets de la liste
            Destroy(_instanciedSystemPrefabs[i]);

        _instanciedSystemPrefabs.Clear();

        base.OnDestroy(); // Appelle la méthode parente pour détruire le singleton
    }


    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        ao.completed += OnLoadOperationComplete;

        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to load level " + levelName);
            return;
        }
        _loadOperations.Add(ao);
        _currentLevelName = levelName;

        if (_currentLevelName != scenesNames[0] && _currentLevelName != scenesNames[1])
            UIManager.Instance.EnablePlayerUI(true);

        DontDestroyOnLoad(gameObject); // Empéche la destruction du GameManage
    }

    public void LoadNextLevel() // Permet de déduire le niveau suivant et de le charger
    {
        for (int i = 0; i < scenesNames.Length; ++i)
        {
            if (scenesNames[i] == _currentLevelName)
            {
                UnloadLevel(_currentLevelName);
                LoadLevel(scenesNames[i + 1]);
                _currentLevelName = scenesNames[i + 1];

                Debug.Log("Current level is : " + _currentLevelName);

                // Pour éviter de charger une scène qui n'existe pas
                //++i;
                break;
            }
        }
    }

    public void LoadSelectedLevel(int number)
    {
        number++;
        // Comprend les scène d'into et la cinématique
        string sceneToLoad = GameManager.Instance.scenesNames[number];
        UIManager.Instance.StartGame(sceneToLoad);
    }

    public bool IsLastLevel
    {
        get { return isLastLevel; }
    }

    public bool IsIntroductionLevel()
    {
        if (_currentLevelName == scenesNames[0])
            return true;
        else
            return false;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        ao.completed += OnUnloadOperationComplete;

        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to unload level " + levelName);
            return;
        }
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Load complete !");
        if (_loadOperations.Contains(ao))
            _loadOperations.Remove(ao);
    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload complete !");
    }

    public void MainMenuReturn()
    {
        SceneManager.UnloadSceneAsync(_currentLevelName);
        SceneManager.UnloadSceneAsync("Boot");
        Destroy(gameObject);
        SceneManager.LoadSceneAsync("Boot");
    }

    public void RestartGame() // Restart
    {
        UnloadLevel(_currentLevelName);
        LoadLevel(_currentLevelName);
    }

    public void QuitGame() // Quit
    {
        Application.Quit();
    }

}
