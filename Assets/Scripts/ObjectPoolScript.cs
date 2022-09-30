using UnityEngine;

public class ObjectPoolScript : MonoBehaviour
{

    [SerializeField]
    private GameObject blueTruck;
    [SerializeField]
    private GameObject blueTruckFolder;
    [SerializeField]
    private GameObject sedan;
    [SerializeField]
    private GameObject sedanFolder;
    [SerializeField]
    private GameObject hatchBack;
    [SerializeField]
    private GameObject hatchBackFolder;
    [SerializeField]
    private GameObject bus;
    [SerializeField]
    private GameObject busFolder;
    [SerializeField]
    private GameObject car1;
    [SerializeField]
    private GameObject car1Folder;
    [SerializeField]
    private GameObject car2;
    [SerializeField]
    private GameObject car2Folder;
    [SerializeField]
    private GameObject car3;
    [SerializeField]
    private GameObject car3Folder;
    [SerializeField]
    private GameObject car4;
    [SerializeField]
    private GameObject car4Folder;
    [SerializeField]
    private GameObject suv;
    [SerializeField]
    private GameObject suvFolder;
    [SerializeField]
    private GameObject suv2;
    [SerializeField]
    private GameObject suv2Folder;
    [SerializeField]
    private GameObject truck1;
    [SerializeField]
    private GameObject truck1Folder;
    [SerializeField]
    private GameObject truck2;
    [SerializeField]
    private GameObject truck2Folder;


    // Use this for initialization
    void Start()
    {
        InstantiateObjets(blueTruck, 3, blueTruckFolder);
        InstantiateObjets(sedan, 3, sedanFolder);
        InstantiateObjets(hatchBack, 3, hatchBackFolder);
        InstantiateObjets(bus, 3, busFolder);
        InstantiateObjets(car1, 3, car1Folder);
        InstantiateObjets(car2, 3, car2Folder);
        InstantiateObjets(car3, 3, car3Folder);
        InstantiateObjets(car4, 3, car4Folder);
        InstantiateObjets(suv, 3, suvFolder);
        InstantiateObjets(suv2, 3, suv2Folder);
        InstantiateObjets(truck1, 3, truck1Folder);
        InstantiateObjets(truck2, 3, truck2Folder);
        InstantiateObjets(truck1, 3, truck1Folder);
        InstantiateObjets(truck2, 3, truck2Folder);
    }

    /// <summary>
    /// Returns a box or pin GameObject based on the passed arguments.
    /// </summary>
    /// <param name="type">Type of car you want, 1 is blue truck, 2 is sedan, 3 is hatchback</param>
    /// <returns>Returns a car GameObject based on the passed arguments.</returns>
    public GameObject GetObject(int type, Vector3 position, Quaternion rotation)
    {
        GameObject obj;
        switch (type)
        {
            case 1:
                obj = blueTruckFolder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 2:
                obj = sedanFolder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 3:
                obj = hatchBackFolder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 4:
                obj = busFolder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 5:
                obj = car1Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 6:
                obj = car2Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 7:
                obj = car3Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 8:
                obj = suvFolder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 9:
                obj = truck1Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 10:
                obj = truck2Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 11:
                obj = car4Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            case 12:
                obj = suv2Folder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
            default:
                obj = blueTruckFolder.transform.GetChild(0).gameObject;
                obj.SetActive(true);
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.transform.parent = null;
                return obj;
        }
    }
    /// <summary>
    /// Used for returning the object to the pool.
    /// </summary>
    /// <param name="type">Type of object you're returning, 1 is blue truck, 2 is sedan, 3 is hatchback.</param>
    /// <param name="returningObject"> The object you want to return </param>
    public void ReturnObject(GameObject returningObject, int type)
    {
        switch (type)
        {
            case 1:
                ReturnHelper(returningObject, blueTruckFolder);
                break;
            case 2:
                ReturnHelper(returningObject, sedanFolder);
                break;
            case 3:
                ReturnHelper(returningObject, hatchBackFolder);
                break;
            case 4:
                ReturnHelper(returningObject, busFolder);
                break;
            case 5:
                ReturnHelper(returningObject, car1Folder);
                break;
            case 6:
                ReturnHelper(returningObject, car2Folder);
                break;
            case 7:
                ReturnHelper(returningObject, car3Folder);
                break;
            case 8:
                ReturnHelper(returningObject, suvFolder);
                break;
            case 9:
                ReturnHelper(returningObject, truck1Folder);
                break;
            case 10:
                ReturnHelper(returningObject, truck2Folder);
                break;
            case 11:
                ReturnHelper(returningObject, car4Folder);
                break;
            case 12:
                ReturnHelper(returningObject, suv2Folder);
                break;
            default:
                ReturnHelper(returningObject, blueTruckFolder);
                break;
        }
    }

    private void InstantiateObjets(GameObject obj, int number, GameObject parentObj)
    {
        for (int i = 0; i <= number; i++)
        {
            GameObject instanstiatedCar = Instantiate(obj, new Vector3(0, 0, 10000), Quaternion.identity) as GameObject;
            instanstiatedCar.SetActive(false);
            instanstiatedCar.transform.parent = parentObj.transform;
        }
        return;
    }

    private void ReturnHelper(GameObject returnObj , GameObject parentObj) // returns object to object pool
    {
        returnObj.transform.position = new Vector3(0, 0, 10000);
        returnObj.transform.parent = parentObj.transform;
        returnObj.SetActive(false);
    }
}
