using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingObject : MonoBehaviour {

    public float rotationSpeed = 2f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
	}
}
