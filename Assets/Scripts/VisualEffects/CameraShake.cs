using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private static CameraShake instance;

	public static void Shake(float duration, float amplitude)
	{
		instance.duration = duration;
		instance.amplitude = amplitude;
	}

	float duration;
	float amplitude;
	Vector3 originalPosition;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		originalPosition = MainCamera.Get.transform.localPosition;
	}

	void Update()
    {
		if(duration > 0)
		{
			duration -= Time.deltaTime;
			MainCamera.Get.transform.localPosition = originalPosition + new Vector3(Random.Range(-amplitude, amplitude), Random.Range(-amplitude, amplitude));
		}
		else
		{
			MainCamera.Get.transform.localPosition = originalPosition;
		}
    }
}
