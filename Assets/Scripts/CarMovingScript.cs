using UnityEngine;
using DG.Tweening;


public class CarMovingScript : MonoBehaviour {

    public CarSpawner carSpawner;
    public TurntableScript ttScript;
    private GameObject turntable;

    private Collider ttColOne;
    private Collider ttColTwo;

    private Collider roadEndOne;
    private Collider roadEndTwo;
    void Start()
    {
        turntable = GameObject.Find("Turning Road");
        ttScript = turntable.GetComponent<TurntableScript>();
        ttColOne = GameObject.Find("ttEnd #1").GetComponent<Collider>();
        ttColTwo = GameObject.Find("ttEnd #2").GetComponent<Collider>();
        roadEndOne = GameObject.Find("RoadEnd1").GetComponent<Collider>();
        roadEndTwo = GameObject.Find("RoadEnd2").GetComponent<Collider>();
    }

    void Update()
    {
        if (ShouldGo() )
        {
            transform.Translate(transform.forward * carSpawner.speed * Time.deltaTime, Space.World);
        }
    }

    bool ShouldGo()
    {
        return !ttScript.isTurning ||
            !(ttColOne.bounds.Contains(transform.position) || ttColTwo.bounds.Contains(transform.position) ||
            roadEndOne.bounds.Contains(transform.position) || roadEndTwo.bounds.Contains(transform.position)
            );
    }

    public void Shake()
    {
        Sequence shakeSequence = DOTween.Sequence();
        shakeSequence.Append(transform.DOLocalMoveZ(transform.localPosition.z + 0.1f, 0.5f));
        shakeSequence.Append(transform.DOLocalMoveZ(transform.localPosition.z - 0.1f, 0.5f));
        shakeSequence.SetLoops(-1,LoopType.Restart);
    }
}
