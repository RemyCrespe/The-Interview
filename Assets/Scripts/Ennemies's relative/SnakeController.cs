using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : EnnemyController {

    private Animator snakeAnim;

    new void Start()
    {
        snakeAnim = gameObject.GetComponent<Animator>();
        base.Start();
    }

    private new void OnTriggerEnter2D(Collider2D hit) // Redéfinition de la méthode
    {
        if (hit.tag == "Player")
        {
            snakeAnim.SetBool("isAttacking", true);
            base.OnTriggerEnter2D(hit); // Execution de la méthode héritée
        }
    }

    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.tag == "Player")
            snakeAnim.SetBool("isAttacking", false);
    }
}
