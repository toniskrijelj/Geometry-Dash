using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MainCamera
{
	private static Camera _mainCamera;
	public static Camera Get
	{
		get
		{
			if(_mainCamera == null)
			{
				_mainCamera = Camera.main;
			}
			return _mainCamera;
		}
	}
}
