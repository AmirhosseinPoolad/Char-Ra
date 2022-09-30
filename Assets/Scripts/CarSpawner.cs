using UnityEngine;
using MovementEffects;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour {

    private static int lastRandomNumber;
    public GameObject[] roadStarts = new GameObject[4];
    public GameObject car;

    public float speed;
    [SerializeField]
    public float minSpeed = 6;

    [SerializeField]
    private HighScoreScript highScoreScript;

    public bool shouldCheckDown = true;
    public GameObject gameOverStuff;

    private ObjectPoolScript objPoolScript;
    [SerializeField]
    private GameObject objPool;

    public int fuckUpTimes;
    public bool canGoAnywhere;
    public bool isTunnelTuringMode;

    public Material[] truckMat = new Material[4];
    public Material[] sedanMat = new Material[4];
    public Material[] hatchbackMat = new Material[4];
    public Material[] busMat = new Material[4];
    public Material[] car1Mat = new Material[4];
    public Material[] car2Mat = new Material[4];
    public Material[] car3Mat = new Material[4];
    public Material[] car4Mat = new Material[4];
    public Material[] suvMat = new Material[4];
    public Material[] suv2Mat = new Material[4];
    public Material[] truck1Mat = new Material[4];
    public Material[] truck2Mat = new Material[4];

    private Material[][] carsMat = new Material[13][];

    private readonly float[] yStartingPos = {1.5f , 1.5f, 1.7f, 1.5f, 1.4f, 1.15f, 1.15f, 1.05f, 1.1f, 1.3f, 1.2f, 1.18f, 1.26f};

    public TurntableScript ttScript;

    public GameObject[] crosses = new GameObject[3];
    public float timeSinceLastLoad = 0;

    // Use this for initialization
    void Start () {

        carsMat[1] = truckMat;
        carsMat[2] = sedanMat;
        carsMat[3] = hatchbackMat;
        carsMat[4] = busMat;
        carsMat[5] = car1Mat;
        carsMat[6] = car2Mat;
        carsMat[7] = car3Mat;
        carsMat[8] = suvMat;
        carsMat[9] = truck1Mat;
        carsMat[10] = truck2Mat;
        carsMat[11] = car4Mat;
        carsMat[12] = suv2Mat;

        objPoolScript = objPool.GetComponent<ObjectPoolScript>();
        Timing.RunCoroutine(SpawnCars());
        Timing.RunCoroutine(SetSpeed());
    }

    IEnumerator<float> SpawnCars()
    {
        while (true)
        {
            int roadIndex;
            if (canGoAnywhere)
            {
                yield return Timing.WaitForSeconds(1.5f);
                roadIndex = generateRandomNumber(0, 4);
            }
            else
            {
                yield return Timing.WaitForSeconds(3);
                roadIndex = generateRandomNumber(0, 4);
            }
            int type = Random.Range(5, 13);
            Vector3 pos;
            Material[] passingMaterial;
            pos = new Vector3(roadStarts[roadIndex].transform.position.x, yStartingPos[type], roadStarts[roadIndex].transform.position.z);
            passingMaterial = carsMat[type];
            Vector3 direction;
            switch (roadIndex)
            {
                case 0:
                    direction = new Vector3(-1, 0, 0);
                    break;
                case 1:
                    direction = new Vector3(0, 0, 1);
                    break;
                case 2:
                    direction = new Vector3(1, 0, 0);
                    break;
                case 3:
                    direction = new Vector3(0, 0, -1);
                    break;
                default:
                    direction = Vector3.zero;
                    break;
            }
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            GameObject car = objPoolScript.GetObject(type, pos, targetRotation);
            CarDeathChecker carDeathCheckerScript;
            if (car.GetComponent<CarDeathChecker>() == null)
            {
                carDeathCheckerScript = car.AddComponent<CarDeathChecker>();
            }
            else
            {
                carDeathCheckerScript = car.GetComponent<CarDeathChecker>();
            }
            car.GetComponent<CarMovingScript>().ttScript = ttScript;
            car.GetComponent<CarMovingScript>().carSpawner = this;
            carDeathCheckerScript.carSpawner = this;
            carDeathCheckerScript.gameOverStuff = gameOverStuff;
            carDeathCheckerScript.type = type;
            carDeathCheckerScript.ojpScript = objPoolScript;
            carDeathCheckerScript.highScoreScript = highScoreScript;
            carDeathCheckerScript.isNormalMode = canGoAnywhere;
            carDeathCheckerScript.targetMaterials = passingMaterial;
            int target = Random.Range(0, 4);
            carDeathCheckerScript.target = target;
            carDeathCheckerScript.SetTarget();
        }
    }

    public IEnumerator<float> SetSpeed()
    {
        while (true)
        {
            speed = minSpeed + ( (Time.time - timeSinceLastLoad) / 10) + Random.Range(-1, 1); ;
            yield return Timing.WaitForSeconds(12);
        }
    }

    public void FuckUp()
    {
        fuckUpTimes += 1;
        crosses[fuckUpTimes - 1].SetActive(true);

    }
    public static int generateRandomNumber(int min, int max)
    {

        int result = Random.Range(min, max);

        if (result == lastRandomNumber)
        {

            return generateRandomNumber(min, max);

        }

        lastRandomNumber = result;
        return result;

    }
}
