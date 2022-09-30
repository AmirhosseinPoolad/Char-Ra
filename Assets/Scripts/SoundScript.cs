using System.Collections.Generic;
using UnityEngine;
using MovementEffects;
using DG.Tweening;

public class SoundScript : MonoBehaviour {

    public bool played;
    [SerializeField]
    private AudioSource source;

	// Use this for initialization
	void Start () {
        Timing.RunCoroutine(PlaySound());
	}

    IEnumerator<float> PlaySound()
    {
        while (true)
        {
            if (played == true)
            {
                yield return Timing.WaitForSeconds(3);
                source.enabled = true;
                Sequence soundSequence = DOTween.Sequence();
                soundSequence.Append(DOTween.To(() => source.panStereo, x => source.panStereo = x, 1, 5));
                soundSequence.Append(DOTween.To(() => source.panStereo, x => source.panStereo = x, -1, 5));
                soundSequence.SetLoops(-1, LoopType.Yoyo);
                yield break;
            }
            yield return 0f;
        }
    }
}
