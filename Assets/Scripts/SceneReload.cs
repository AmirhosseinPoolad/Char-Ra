using UnityEngine;
using MovementEffects;

public class SceneReload : MonoBehaviour {

    public CarSpawner carSpawner;
    public GameObject gameOverStuff;
    public HighScoreScript hsScript;
    public ObjectPoolScript ojpScript;
    public void Reload()
    {
        GameObject.Find("ObjectPool").GetComponent<ObjectPoolScript>().enabled = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        GameObject.Find("Turning Road").GetComponent<TurntableScript>().enabled = true;
        carSpawner.enabled = true;
        carSpawner.shouldCheckDown = true;
        carSpawner.speed = carSpawner.minSpeed;
        carSpawner.fuckUpTimes = 0;
        carSpawner.timeSinceLastLoad = Time.time;
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in cars)
        {
            car.GetComponent<Rigidbody>().isKinematic = true;
            int type = car.GetComponent<CarDeathChecker>().type;
            ojpScript.ReturnObject(car, type);

        }
        foreach (GameObject cross in carSpawner.crosses)
        {
            cross.transform.position = new Vector3(-75, 10, -2);
            cross.SetActive(false);
        }
        gameOverStuff.SetActive(false);
        hsScript.gameObject.SetActive(true);
        hsScript.SetScore(0);
        Timing.ResumeCoroutines();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
