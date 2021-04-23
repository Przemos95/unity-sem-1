using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	public GameObject floor1;
	public GameObject floor2;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(GameManager.instance.InGame == false)
        {
			return;
        }

		float speed = GameManager.instance.worldSpeed;

		floor1.transform.position -= new Vector3(speed, 0f, 0f);
		floor2.transform.position -= new Vector3(speed, 0f, 0f);

		if (floor2.transform.position.x < 0)
        {
			floor1.transform.position += new Vector3(20 * 2, 0, 0);

			var tmp = floor1;
			floor1 = floor2;
			floor2 = tmp;
        }
	}
}
