using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour {

    [SerializeField] int damagingPower = 1;
    [SerializeField] float timeBetweenHits = 2;
    private float timer = 2;


    public void Start()
    {
        timer = timeBetweenHits;    
    }

    protected void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            Damage();
        }
    }
    

    public void OnTriggerStay2D(Collider2D hit)
    {
        timer -= Time.deltaTime;

        if (hit.tag == "Player" && timer <= 0)
        {
            Damage();
        }

        if (timer <= 0)
            timer = timeBetweenHits;
    }


    private void Damage()
    {
            if (damagingPower > 0)
                PlayerInventory.Instance.Damage(damagingPower);
    }


    public void DestroyEnnemy()
    {
        Destroy(gameObject);
    }
}
