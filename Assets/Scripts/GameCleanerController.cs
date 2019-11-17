using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCleanerController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
            hit.GetComponent<PlayerController>().MakeDead();

        if (hit.tag == "Ennemy")
            hit.GetComponent<EnnemyController>().DestroyEnnemy();

    }
}
