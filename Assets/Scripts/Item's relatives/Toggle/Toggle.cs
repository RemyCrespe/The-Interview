using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    private bool isToggled = false;
    private Animator toggleAnim;

    [SerializeField] GameObject reward;

    public void Start()
    {
        toggleAnim = gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        toggleAnim.SetBool("IsToggled", isToggled);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Toggle !");
                Instantiate(reward, transform.position, Quaternion.identity); // Son
                isToggled = !isToggled;
            }
        }
    }

    public void Reset()
    {
        isToggled = false;
    }

    public void SetPosition(bool toggle)
    {
        isToggled = toggle;
    }

    public bool IsToggled
    {
        get { return isToggled; }
    }
}
