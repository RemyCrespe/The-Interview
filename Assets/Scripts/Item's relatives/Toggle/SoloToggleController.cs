using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloToggleController : MonoBehaviour
{
    private Toggle toggle;
    public GameObject[] gameObjectsTab;

    [SerializeField] GameObject reward;

    public void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
    }

    public void Update()
    {
        Animator goAnimator;

        for (int i = 0; i < gameObjectsTab.Length; ++i)
        {
            goAnimator = gameObjectsTab[i].GetComponent<Animator>();

            if (goAnimator.GetBool("IsToggled") != toggle.IsToggled) // Si la valeur a changé depuis le dernier appel de fonction
                Instantiate(reward, transform.position, Quaternion.identity); // Son

            goAnimator.SetBool("IsToggled", toggle.IsToggled);
        }
    }
}
