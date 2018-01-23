using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Crank : MonoBehaviour {

	public GameObject ObjectToTrack;
	public enum Axes {
		XAXIS, 
		YAXIS, 
		ZAXIS
	};
	public Axes yArcTanAxis;
	public Axes xArcTanAxis;

	void Start(){
		if (yArcTanAxis == xArcTanAxis) {
			throw new UnityException ();
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 objectPosition = transform.InverseTransformPoint(ObjectToTrack.transform.position);
		var x = getAxisOfObject (objectPosition, xArcTanAxis);
		var y = getAxisOfObject (objectPosition, yArcTanAxis);

		var arcTanPosition = -20* Mathf.Atan (x / y);
		float truncated = Mathf.Round(arcTanPosition * 100f) / 100f;
		this.transform.Rotate(0,0, truncated);
	}

	float getAxisOfObject(Vector3 objectPosition, Axes axis){
		switch (axis) {
		case(Axes.XAXIS):
			return objectPosition.x;
		case(Axes.YAXIS):
			return objectPosition.y;
		default:
			return objectPosition.z;
		}
	}

}
