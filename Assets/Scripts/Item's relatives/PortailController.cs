using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortailController : MonoBehaviour
{
    public Collider2D secondPortail;
    [SerializeField] float scale = 0.2f; // Distance où le joueur doit apparaître par rapport au portail
    private static bool isComming;
    [SerializeField] GameObject reward; // Feedback

    public void Start()
    {
        isComming = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isComming)
            {
                isComming = true;
                print("Teleport");
                float x = secondPortail.transform.position.x;
                float y = secondPortail.transform.position.y;
                Instantiate(reward, transform.position, Quaternion.identity); // Son
                collision.GetComponent<PlayerController>().Teleport(x, y, scale);
            }
            else if (isComming)
                isComming = false;
        }
    }

}
