using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] int numberKeyNeeded = 1;
    [SerializeField] GameObject reward; // Feedback

    private Animator doorAnim;

    public void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerInventory.Instance.GetKeyNumber >= numberKeyNeeded)
        {
            doorAnim.SetBool("IsOpened", true);

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerInventory>().GetKeyNumber == numberKeyNeeded)
            {
                doorAnim.SetBool("IsOpened", true);
                Instantiate(reward, transform.position, Quaternion.identity); // Son
                PlayerController.Instance.MakeWin();
            }
            else
            {
                Debug.Log("Player haven't enougth key(s) !");
            }
        }
    }
}

