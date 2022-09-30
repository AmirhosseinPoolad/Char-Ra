using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using MovementEffects;
using DG.Tweening;

public class LilyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Timing.RunCoroutine(Bounce());
        Vector3 translateVector = new Vector3(Random.Range(-3, 4), 0, Random.Range(-3, 4));
        transform.Translate(translateVector);
    }

    IEnumerator<float> Bounce()
    {
        yield return Timing.WaitForSeconds(Random.Range(1f, 5f));
        while (true)
        {
            Vector3 amount = new Vector3(0, 0.2f, 0);
            transform.DOPunchPosition(amount, 2, 0, 1);
            yield return Timing.WaitForSeconds(3);
        }
    }
}
