using UnityEngine;
using System.Collections;
using MovementEffects;
using System.Collections.Generic;

public class CarDeathCheckerTunnelTurningMode : MonoBehaviour
{

    private Bounds fallingBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(8.5f, 8.5f, 8.5f));
    private Bounds middleBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 10));
    public GameObject targetObj;
    public GameObject gameOverStuff;
    public CarSpawner carSpawner;
    public GameObject[] cars;
    public int target;
    public Material[] targetMaterials = new Material[4];
    public int type;
    public ObjectPoolScript ojpScript;
    public HighScoreScript highScoreScript;
    public bool isNormalMode;
    [SerializeField]
    private Vector3[] rayPoints = new Vector3[2];
    private Collider targetColl;

    // Use this for initialization
    void Start () {
        switch (target)
        {
            case 0:
                targetObj = GameObject.Find("RoadEnd1");
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
            case 1:
                targetObj = GameObject.Find("RoadEnd2");;
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
            case 2:
                targetObj = GameObject.Find("RoadEnd3");;
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
            case 3:
                targetObj = GameObject.Find("RoadEnd4");;
                gameObject.GetComponent<Renderer>().material = targetMaterials[target];
                break;
        }
        targetColl = targetObj.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (carSpawner.fuckUpTimes >= 3)
        {
            Timing.RunCoroutine(GameOver());
        }
	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (targetColl.bounds.Contains(transform.position))
        {
            highScoreScript.AddScore(1);
            ojpScript.ReturnObject(gameObject, type);
        }
        else if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            transform.SetParent(hit.transform);
        }
        else if (carSpawner.shouldCheckDown && !Physics.Raycast(rayPoints[0] + transform.position, -Vector3.up) && !Physics.Raycast(rayPoints[1] + transform.position, -Vector3.up))
        {
            if (fallingBounds.Contains(transform.position))
            {
                Timing.RunCoroutine(GameOver());
            }
            else if (!middleBounds.Contains(transform.position))
            {
                carSpawner.fuckUpTimes += 1;
                ojpScript.ReturnObject(gameObject, type);
            }
        }
    }

    IEnumerator<float> GameOver()
    {
        carSpawner.shouldCheckDown = false;
        gameOverStuff.SetActive(true);
        cars = GameObject.FindGameObjectsWithTag("Car");
        carSpawner.speed = 0;
        carSpawner.enabled = false;
        foreach (GameObject car in cars)
        {
            car.GetComponent<Rigidbody>().isKinematic = false;
        }
        while (true)
        {
            if (Time.timeScale <= 0.1f)
            {
                break;                                              // slowing motion
            }
            else
            {
                Time.timeScale -= Time.deltaTime;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
            yield return 0f;
        }
        
    }

}