using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HighScoreScript : MonoBehaviour {

    private int highScore = 0;
    private Text text;

    [SerializeField]
    private Vector3 shakeVector;
    [SerializeField]
    private float shakeTime;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	//void Update () {
        //text.text = highScore.ToString();
	//}

    public void AddScore(int amount)
    {
        highScore += amount;
        //DOTween.Shake(() => transform.position, x => transform.position = x, 0.2f, shakeVector);
        text.text = highScore.ToString();
        //iTween.ShakePosition(gameObject, shakeVector * amount, shakeTime);
    }
    public void SetScore(int amount)
    {
        highScore = amount;
        text.text = highScore.ToString();
    }

    public int GetScore()
    {
        return highScore;
    }
}
