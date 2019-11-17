using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    [SerializeField] GameObject reward; // Feedback
    [SerializeField] int value = 1; // Valeur de 1 par défaut

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerInventory>().AddCoin(value);
            Instantiate(reward, transform.position, Quaternion.identity); // Son
            Destroy(gameObject.transform.root.gameObject); // Destruction de la pièce
        }
    }
}
