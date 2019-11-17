using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour {

    [SerializeField] GameObject reward; // Feedback

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().GetHelthPower < 3)
            {
                collision.GetComponent<PlayerInventory>().AddHealth();
                Instantiate(reward, transform.position, Quaternion.identity); // Son
                Destroy(gameObject.transform.root.gameObject); // Destruction de la potion
            }
            else
                print("Le personnage a trop de PVs pour prendre une potion !");
        }
    }
}
