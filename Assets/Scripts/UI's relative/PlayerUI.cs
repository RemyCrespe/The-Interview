using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : Singleton<PlayerUI>
{
    // Données pour la gestion de l'affichage des coeurs
    [SerializeField] Image heart1;
    [SerializeField] Image damagedHeart1;
    [SerializeField] Image heart2;
    [SerializeField] Image damagedHeart2;
    [SerializeField] Image heart3;
    [SerializeField] Image damagedHeart3;

    [SerializeField] Text coinsDisplayer; // Compteur des pièces

    [SerializeField] Text keysDisplayer; // Compteur des clés

    // Gestion de l'affichage des coeurs
    public void ActualizePVsView()
    {
        int health = PlayerInventory.Instance.GetHelthPower;
        Debug.Log("Health is about " + health + "/3.");

        switch (health)
        {
            case 3:
                heart3.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                damagedHeart3.gameObject.SetActive(false);
                damagedHeart2.gameObject.SetActive(false);
                damagedHeart1.gameObject.SetActive(false);
                break;
            case 2:
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                damagedHeart3.gameObject.SetActive(true);
                damagedHeart2.gameObject.SetActive(false);
                damagedHeart1.gameObject.SetActive(false);
                break;
            case 1:
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart1.gameObject.SetActive(true);
                damagedHeart3.gameObject.SetActive(true);
                damagedHeart2.gameObject.SetActive(true);
                damagedHeart1.gameObject.SetActive(false);
                break;
            case 0:
                print("Game Over !");
                heart1.gameObject.SetActive(false);
                damagedHeart3.gameObject.SetActive(false);
                damagedHeart2.gameObject.SetActive(false);
                damagedHeart1.gameObject.SetActive(false);
                PlayerController.Instance.MakeDead();
                break;
            default:
                print("Comportement annormal au niveau de l'affichage des PVs.");
                break;
        }
    }

    // Gestion du compteur de pièces
    public void ActualizeCoinsView()
    {
        coinsDisplayer.text = PlayerInventory.Instance.GetCoinNumber.ToString();
    }

    public void ActualizeKeysView()
    {
        keysDisplayer.text = PlayerInventory.Instance.GetKeyNumber.ToString();
    }

}
