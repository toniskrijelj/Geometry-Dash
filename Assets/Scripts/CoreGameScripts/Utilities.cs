using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
	public static float SignClamp(float value, float sign, float min, float max)
	{
		if(sign > 0)
		{
			return Mathf.Min(value, max);
		}
		return Mathf.Max(value, min);
	}
}
