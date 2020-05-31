using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LockToGrid : MonoBehaviour
{
	[SerializeField] private bool lockPosition = true;
	[SerializeField] private bool lockScale = true;

    void Update()
    {
		if (!Application.isPlaying)
		{
			if (lockPosition)
			{
				transform.position = new Vector3(Mathf.CeilToInt(transform.position.x) - .5f, Mathf.CeilToInt(transform.position.y) - .5f, transform.position.z);
			}
			if (lockScale)
			{
				float xClamp = Mathf.RoundToInt(transform.localScale.x);
				if (xClamp % 2 == 0)
				{
					xClamp -= 1;
				}
				float yClamp = Mathf.RoundToInt(transform.localScale.y);
				if (yClamp % 2 == 0)
				{
					yClamp -= 1;
				}
				transform.localScale = new Vector3(xClamp, yClamp, 1);
			}
		}
		else
		{
			Destroy(this);
		}
	}
}
