using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MovementEffects;
using DG.Tweening;

public class CarDeathChecker : MonoBehaviour {

    private Bounds fallingBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(8.5f, 8.5f, 8.5f));
    private Bounds middleBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 10));
    public Bounds targetBounds;
    public GameObject gameOverStuff;
    public CarSpawner carSpawner;
    public GameObject[] cars;
    public int target;
    public Material[] targetMaterials = new Material[4];
    public int type;
    public ObjectPoolScript ojpScript;
    public HighScoreScript highScoreScript;
    public bool isNormalMode;

    // Use this for initialization
    public void SetTarget () {
        switch (target)
        {
            case 0:
                this.targetBounds = new Bounds(new Vector3(25, 0, 0), new Vector3(8, 8, 8));
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
            case 1:
                this.targetBounds = new Bounds(new Vector3(0, 0, -25), new Vector3(8, 8, 8));
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
            case 2:
                this.targetBounds = new Bounds(new Vector3(-25, 0, 0), new Vector3(8, 8, 8));
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
            case 3:
                this.targetBounds = new Bounds(new Vector3(0, 0, 25), new Vector3(8, 8, 8));
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
        }
    }
	
	// Update is called once per frame
    void Update () {
        if (carSpawner.fuckUpTimes >= 3)
        {
            GameOver();
        }
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            transform.SetParent(hit.transform);
        }
        else if (carSpawner.shouldCheckDown)
        {
            if (isNormalMode)
            {
                if (fallingBounds.Contains(transform.position))
                {
                    GameOver();
                }
                else if (targetBounds.Contains(transform.position))
                {
                    highScoreScript.AddScore(5);
                    ojpScript.ReturnObject(gameObject, type);
                }
                else if (!middleBounds.Contains(transform.position))
                {
                    highScoreScript.AddScore(1);
                    ojpScript.ReturnObject(gameObject, type);
                }
            }
            else
            {
                if (fallingBounds.Contains(transform.position))
                {
                    GameOver();
                }
                else if (targetBounds.Contains(transform.position))
                {
                    highScoreScript.AddScore(1);
                    ojpScript.ReturnObject(gameObject, type);
                }
                else if (!middleBounds.Contains(transform.position))
                {
                    carSpawner.FuckUp();
                    ojpScript.ReturnObject(gameObject, type);
                }
            }
        }
    }

    public void GameOver()
    {
        carSpawner.shouldCheckDown = false;
        gameOverStuff.SetActive(true);
        GameObject.Find("ScoreText").GetComponent<Text>().text = string.Format("score: {0}", highScoreScript.GetScore());
        GameObject.Find("LivingTimeText").GetComponent<Text>().text = string.Format("Time Alive: {0} Seconds", Mathf.Round( (Time.time - carSpawner.timeSinceLastLoad) * 100 ) / 100);
        GameObject.Find("Turning Road").GetComponent<TurntableScript>().enabled = false;
        carSpawner.speed = 0;
        carSpawner.enabled = false;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetInt("HighScore") < highScoreScript.GetScore())
            {
                PlayerPrefs.SetInt("HighScore", highScoreScript.GetScore());
            }
        }
        else{
            PlayerPrefs.SetInt("HighScore", highScoreScript.GetScore());
        }
        GameObject.Find("HighScoreText").GetComponent<Text>().text = string.Format("Highscore: {0}", PlayerPrefs.GetInt("HighScore"));
        GameObject.Find("ObjectPool").GetComponent<ObjectPoolScript>().enabled = false;
        cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in cars)
        {
            car.GetComponent<CarMovingScript>().enabled = false;
            car.GetComponent<CarDeathChecker>().enabled = false;
        }

        highScoreScript.gameObject.SetActive(false);
        //DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0.1f, 0.05f); //lowers time scale
        // DOTween.To(() => Time.fixedDeltaTime, x => Time.fixedDeltaTime = x, 0.002f, 0.05f); // lowers phys time scale too
        Timing.PauseCoroutines();
    }

}