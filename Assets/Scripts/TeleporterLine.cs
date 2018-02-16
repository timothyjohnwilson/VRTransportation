using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterLine : MonoBehaviour {

	// Creates a line renderer that follows a Sin() function
	// and animates it.

	public Color c1 = Color.red;
	public Color c2 = Color.red;
	public GameObject Teleporter;
	public GameObject hand;

	public void initialize()
	{
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.widthMultiplier = 0.05f;
		lineRenderer.positionCount = 2;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineRenderer.colorGradient = gradient;
	}

	public void Display(Vector3 teleportPosition){
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		var t = Time.time;
		Debug.Log (hand.transform.position);
		Debug.Log (Teleporter.transform.position);
		Vector3 controllerPosition = new Vector3 (hand.transform.position.x, hand.transform.position.y, hand.transform.position.z);
		Vector3[] positions = { controllerPosition, teleportPosition };
		lineRenderer.SetPositions(positioSns);
	}

	public void Hide(){
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		var t = Time.time;
		Vector3 controllerPosition = new Vector3 (0, 0, 0);
		Vector3 teleporterPosition = new Vector3 (0, 0, 0);
		Vector3[] positions = { controllerPosition, teleporterPosition };
		lineRenderer.SetPositions(positions);
	}

	public void updateColor(Color c1, Color c2){
		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		Gradient gradient = new Gradient();
		float alpha = 1.0f;
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineRenderer.colorGradient = gradient;

	}
}
