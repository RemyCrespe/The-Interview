using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicExit : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Cinematic exit");
            GameManager.Instance.LoadNextLevel();
        }
    }
}
