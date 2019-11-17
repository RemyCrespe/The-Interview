using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _mainMenuAnimator;

    [SerializeField] GameObject _levelSelectorMenu;


    public void FadeIn() // Joue l'annimation de démarrage du menu principal
    {
        _mainMenuAnimator.SetBool("isFadingIn", true);
        UIManager.Instance.SetDummyCameraActive(true);
        _mainMenuAnimator.ResetTrigger("isFadingIn");

    }

    public void FadeOut() // Idem pour l'annimation de sortie
    {
        _mainMenuAnimator.SetBool("isFadingOut", true);
        UIManager.Instance.SetDummyCameraActive(false);
    }


    public void StartButton()
    {
        FadeOut();
        UIManager.Instance.StartGame(GameManager.Instance.scenesNames[0]);
    }

    public void SelectLevelButton(bool show)
    {
        _levelSelectorMenu.gameObject.SetActive(show);
    }

}
