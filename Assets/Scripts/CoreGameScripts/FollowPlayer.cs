using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private void Update()
    {
		transform.position = new Vector3(MainCamera.Get.transform.position.x + 2, transform.position.y);
    }
}
