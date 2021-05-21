using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour {
		
	void FixedUpdate () {
		if (GameManager.instance.InGame == false)
		{
			return;
		}

        transform.position -= new Vector3(GameManager.instance.worldSpeed, 0f, 0f);
    }
}
