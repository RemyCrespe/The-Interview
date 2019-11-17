using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSuiteController : MonoBehaviour
{
    public Toggle[] toggleTabOrder;
    public GameObject[] gameObjectsTab;
    private bool isSuiteOK= false;

    [SerializeField] GameObject reward;
    private bool isOKFeedbackPlayed = false;

    public void Update()
    {
        bool isOneUntoggled = false;

        for (int i = 0; i < toggleTabOrder.Length; ++i)
        {
            if (toggleTabOrder[i].IsToggled)
            {
                if (isOneUntoggled)
                {
                    Debug.Log("U did a mistake !");
                    if (isSuiteOK)
                    {
                        isSuiteOK = false;
                        isOKFeedbackPlayed = false;
                        Instantiate(reward, transform.position, Quaternion.identity); // Son
                    }

                    ResetAll();
                    break;
                }
                else if (i == toggleTabOrder.Length - 1)
                {
                    isSuiteOK = true;

                    if (!isOKFeedbackPlayed)
                    {
                        Debug.Log("Suite OK");
                        Instantiate(reward, transform.position, Quaternion.identity); // Son
                        isOKFeedbackPlayed = true;
                    }
                }
                else
                    continue;
            }
            else
                isOneUntoggled = true;
        }

        Animator goAnimator;

        for (int i = 0; i < gameObjectsTab.Length; ++i)
        {
            goAnimator = gameObjectsTab[i].GetComponent<Animator>();

            goAnimator.SetBool("IsToggled", isSuiteOK);
        }
    }

    public void ResetAll()
    {
        for (int i = 0; i < toggleTabOrder.Length; ++i)
        {
            toggleTabOrder[i].Reset();
        }
    }

}
