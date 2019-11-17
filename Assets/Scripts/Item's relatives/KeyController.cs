using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] GameObject reward;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().AddKey(); // Ajoute la clé dans l'inventaire
            Instantiate(reward, transform.position, Quaternion.identity); // Son
            Debug.Log("Key Added !");
            Destroy(gameObject.transform.root.gameObject); // Détruit la clé
        }    
    }
}
