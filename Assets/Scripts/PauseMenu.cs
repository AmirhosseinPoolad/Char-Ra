using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private GameObject pauseObject;
    [SerializeField]
    private TurntableScript turnTableScript;
    private bool paused;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

     public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        turnTableScript.enabled = false;
        pauseObject.SetActive(true);
    }

     public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        turnTableScript.enabled = true;
        pauseObject.SetActive(false);
    }

     public void Exit()
     {
         Application.Quit();
     }
}
