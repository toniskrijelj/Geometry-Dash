using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
	/*
	[SerializeField] float timeToFadeOut = .2f;
	[SerializeField] float timeToScaleOut = .5f;

	PlayerVisual copy = null;
	float timer = 0;
	[SerializeField] float timerMax = .05f;
	
    void Update()
    {
		if(copy == null)
		{
			copy = transform.GetChild(0).GetChild(0).GetComponent<PlayerVisual>();
		}
		timer += Time.deltaTime;
		if(timer > timerMax)
		{
			timer -= timerMax;
			PlayerVisual newVisual = Instantiate(copy, copy.transform.position, copy.transform.rotation);
			Vector3 scale = copy.transform.localScale;
			scale.y *= -Player.instance.gravityScale;
			newVisual.transform.localScale = scale;
			newVisual.FadeOutAndReduce(timeToFadeOut, timeToScaleOut);
			Destroy(newVisual.gameObject, Mathf.Min(timeToFadeOut, timeToScaleOut));
		}
    }*/
}
