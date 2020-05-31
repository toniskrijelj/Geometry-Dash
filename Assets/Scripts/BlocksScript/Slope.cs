using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
	public static List<Slope> activeSlopes = new List<Slope>();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.attachedRigidbody.velocity = new Vector2(Player.XSpeed, Player.XSpeed * transform.localScale.x * transform.localScale.y);
		PlayerMode.instance.transform.localEulerAngles = new Vector3(0, 0, 45 * transform.localScale.x * transform.localScale.y * -Player.gravityScale);
		activeSlopes.Add(this);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		activeSlopes.Remove(this);
	}
	
}
