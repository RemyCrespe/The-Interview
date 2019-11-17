using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleResetter : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    public void OnTriggerEnter2D()
    {
        toggle.SetPosition(false);
        Debug.Log("Toggle has been resetted !");
    }
}
