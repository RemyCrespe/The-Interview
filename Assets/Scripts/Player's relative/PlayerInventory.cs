using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Singleton<PlayerInventory> {

    [SerializeField] int healthPower = 3; // Points de vie
    private int coinNumber = 0; // Nombre de pièces
    private int keyNumber = 0;
    [SerializeField] GameObject feedbackDamage; // Feedback
    Rigidbody2D playerRB; // Utilisation du Rigidbody2D
    void Start()
    {
        // Mise a 0 du compteur (initialisation)
        PlayerUI.Instance.ActualizeCoinsView();
        PlayerUI.Instance.ActualizePVsView();
        PlayerUI.Instance.ActualizeKeysView();
        playerRB = GetComponent<Rigidbody2D>(); 
    }

    // Health's method
    public void Damage(int damagingPower)
    {
        healthPower -= damagingPower;
        Instantiate(feedbackDamage, transform.position, Quaternion.identity); // Son
        print("Vie restante : " + healthPower);
        PlayerUI.Instance.ActualizePVsView();
        //Pousse le joueur s'il subit des dégats
        playerRB.velocity = Vector2.zero;
        playerRB.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

    }

    // Add coin's method
    public void AddCoin(int coinsToAdd)
    {
        coinNumber += coinsToAdd;
        print("Pièces récoltées : " + coinNumber);
        PlayerUI.Instance.ActualizeCoinsView();

    }

    // Add health's method (with potion)
    public void AddHealth()
    {
        healthPower++;
        print("PVs : " + healthPower);
        PlayerUI.Instance.ActualizePVsView();

    }

    public void AddKey()
    {
        keyNumber++;
        PlayerUI.Instance.ActualizeKeysView();
    }

    public int GetCoinNumber
    {
        get { return coinNumber; }
    }

    public int GetHelthPower
    {
        get { return healthPower; }
    }

    public int GetKeyNumber
    {
        get { return keyNumber; }
    }

}
