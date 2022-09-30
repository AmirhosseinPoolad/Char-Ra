using UnityEngine;
using DG.Tweening;

public class TurntableScript : MonoBehaviour {

    public float speed;
    private Vector3 targetRotation;
    public bool isTurning = false;
    private float middlePoint;

    void Start()
    {
        middlePoint = Screen.height / 2;
        targetRotation = transform.eulerAngles;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            if (Input.mousePosition.x > middlePoint)
            {
                targetRotation.y %= 360;
                targetRotation = new Vector3(transform.eulerAngles.x, targetRotation.y + 90, transform.eulerAngles.z);
                transform.DORotate(targetRotation, 0.2f, RotateMode.Fast).OnComplete(OnSwipeComplete);
                isTurning = true;
            }
            else if (Input.mousePosition.x < middlePoint)
            {
                targetRotation.y %= 360;
                targetRotation = new Vector3(transform.eulerAngles.x, targetRotation.y - 90, transform.eulerAngles.z);
                transform.DORotate(targetRotation, 0.2f, RotateMode.Fast).OnComplete(OnSwipeComplete);
                isTurning = true;
            }
        }

        else if(Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetButtonDown("d"))
            {
                targetRotation.y %= 360;
                targetRotation = new Vector3(transform.eulerAngles.x, targetRotation.y + 90, transform.eulerAngles.z);
                transform.DORotate(targetRotation, 0.2f, RotateMode.Fast).OnComplete(OnSwipeComplete);
                isTurning = true;
            }
            else if (Input.GetButtonDown("a"))
            {
                targetRotation.y %= 360;
                targetRotation = new Vector3(transform.eulerAngles.x, targetRotation.y - 90, transform.eulerAngles.z);
                transform.DORotate(targetRotation, 0.2f, RotateMode.Fast).OnComplete(OnSwipeComplete);
                isTurning = true;
            }
        }
    }
    void OnSwipeComplete()
    {
        isTurning = false;
    }
}
