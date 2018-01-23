using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedMovement : MonoBehaviour {
	public float modifier;
	public float endPoint;
	void Update () {
		if (transform.position.x < endPoint) {
			transform.Translate ((Vector3.forward * Time.deltaTime) / modifier);
		}
	}
}
