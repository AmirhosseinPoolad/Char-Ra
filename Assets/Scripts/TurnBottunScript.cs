using UnityEngine;
using System.Collections;

public class TurnBottunScript : MonoBehaviour {

    private int clickTimes = 0;

    public void onClick()
    {
        clickTimes += 1;
        if (clickTimes >= 3)
        {
            Destroy(gameObject);
        }
    }
}
