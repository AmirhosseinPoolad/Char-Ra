using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

    public GameObject menu;
    public GameObject credits;

    public void GoToCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
