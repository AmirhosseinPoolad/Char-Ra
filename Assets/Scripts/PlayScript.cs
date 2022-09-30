using UnityEngine;

public class PlayScript : MonoBehaviour {

    public GameObject Menu;
    public CarSpawner carSpawner;
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject highScore;
    public GameObject soundObject;

    // Use this for initialization
    void Start () {
	}

    public void Quit()
    {
        Application.Quit();
    }

    public void Play(bool isFreeMode)
    {
        GameObject.Find("Turning Road").GetComponent<TurntableScript>().enabled = true;
        carSpawner.enabled = true;
        carSpawner.timeSinceLastLoad = Time.time;
        carSpawner.canGoAnywhere = isFreeMode;
        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
        highScore.SetActive(true);
        soundObject.GetComponent<SoundScript>().played = true; ;
        Destroy(Menu);
    }
}
