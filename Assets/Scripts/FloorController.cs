using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {
	public GameObject floor1;
	public GameObject floor2;

	public GameObject[] floors;
	
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
			var randomFloor = floors[Random.Range(0, floors.Length)];
			var newFloor = Instantiate(randomFloor, new Vector3(20, 0, 0), Quaternion.identity);

			Destroy(floor1);
			floor1 = floor2;
			floor2 = newFloor;
        }
	}
}
