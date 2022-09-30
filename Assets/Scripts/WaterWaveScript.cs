using UnityEngine;
using System.Collections;
using DG.Tweening;

public class WaterWaveScript : MonoBehaviour {


	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        float timeSine = Mathf.PingPong(Time.time, 2) - 1 ;
        transform.eulerAngles = new Vector3(timeSine, 0, -timeSine);
	}
}
