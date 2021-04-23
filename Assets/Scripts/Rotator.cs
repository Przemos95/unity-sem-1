using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float rotationSpeed;

	void FixedUpdate () {
		transform.Rotate(new Vector3(0, 0, rotationSpeed));
	}
}
