using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] UnityEvent OnClickUnityEvent = null;
	private Action OnClick;

	bool holding;
	bool onButton;
	Vector2 currentScale;
	Vector2 baseScale;

	public void OnPointerEnter(PointerEventData eventData)
	{
		onButton = true;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		onButton = false;
	}

	private void Awake()
	{
		currentScale = transform.localScale;
		baseScale = transform.localScale;
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			holding = true;
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(onButton)
			{
				OnClick?.Invoke();
				OnClickUnityEvent?.Invoke();
			}
			holding = false;
		}
		if (holding && onButton)
		{
			currentScale.x = Utilities.SignClamp(currentScale.x + Time.unscaledDeltaTime * 3 * baseScale.x, baseScale.x, baseScale.x * 1.2f, baseScale.x * 1.2f);
			currentScale.y = Utilities.SignClamp(currentScale.y + Time.unscaledDeltaTime * 3 * baseScale.y, baseScale.y, baseScale.y * 1.2f, baseScale.y * 1.2f);
			transform.localScale = currentScale;
		}
		else if (currentScale.x != baseScale.x || currentScale.y != baseScale.y)
		{
			currentScale.x = Utilities.SignClamp(currentScale.x - Time.unscaledDeltaTime * 3 * baseScale.x, -baseScale.x, baseScale.x, baseScale.x);
			currentScale.y = Utilities.SignClamp(currentScale.y - Time.unscaledDeltaTime * 3 * baseScale.y, -baseScale.y, baseScale.y, baseScale.y);
			transform.localScale = currentScale;
		}
	}

	public void SetOnClick(Action OnClick)
	{
		this.OnClick = OnClick;
	}
}
