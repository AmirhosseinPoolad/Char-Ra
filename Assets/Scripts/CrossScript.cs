using UnityEngine;
using DG.Tweening;

public class CrossScript : MonoBehaviour {

    public Vector2 targetPosition;
    private RectTransform rt;

	// Use this for initialization
    void OnEnable()
    {
        DOTween.To( () => rt.anchoredPosition, x => rt.anchoredPosition = x, targetPosition, 1);
	}
	
	void Start () {
        rt = gameObject.GetComponent<RectTransform>();
	}
}
