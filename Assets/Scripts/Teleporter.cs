using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {


	public GameObject TeleportMarker;
	public Transform Controller;
	public float RayLength = 500f;
	public TeleporterLine teleporterLine;
	public bool allowVertical = false;
	public float platformCheckDistance = 2;
	public float platformHeightDistance = 3;
	private bool pressed;
	private CharacterController characterController;

	// Use this for initialization
	void Start () {
		//Map the Device from user input
		TeleportMarker.SetActive (false);
		teleporterLine.initialize ();
		pressed = false;
		characterController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (Controller.transform.position, Controller.transform.forward);
		TeleporterController (ray);
	}

	void TeleporterController(Ray ray){
		RaycastHit hit;
		bool detected = Physics.Raycast (ray, out hit, RayLength);
		Vector3 markerPosition = TeleportMarker.transform.position;
		//Handle when the user presses 'A'
		if (OVRInput.GetDown (OVRInput.RawButton.A)) {
			pressed = true;
		} else if (OVRInput.GetUp (OVRInput.RawButton.A)) {
			pressed = false;
			teleporterLine.Hide ();
			if(hit.collider.tag == "Ground" && checkPositions(hit))
				transform.position = new Vector3(hit.point.x, hit.point.y + characterController.height, hit.point.z);
		}
		//Line Handling
		if (pressed) {
			if (detected && hit.collider.tag == "Ground" && checkPositions(hit)) {
				teleporterLine.updateColor (Color.green, Color.green);
				TeleportMarker.SetActive (true);
				TeleportMarker.transform.position = hit.point;
				teleporterLine.Display (TeleportMarker.transform.position);
			} else {
				teleporterLine.updateColor (Color.red, Color.red);
				TeleportMarker.SetActive (false);
				Ray ray2 = new Ray (Controller.transform.position, Controller.transform.forward);
				teleporterLine.Display (ray2.GetPoint(RayLength));
			}

		} else {
			
			TeleportMarker.SetActive (false);
		}
			
	}

	public bool checkPositions( RaycastHit hit){
		if (Physics.CheckSphere (new Vector3 (hit.point.x + platformCheckDistance, hit.point.y- platformHeightDistance, hit.point.z + platformCheckDistance),1)) {
			if (Physics.CheckSphere (new Vector3 (hit.point.x - platformCheckDistance, hit.point.y- platformHeightDistance, hit.point.z - platformCheckDistance),1)) {
				if (Physics.CheckSphere (new Vector3 (hit.point.x + platformCheckDistance, hit.point.y- platformHeightDistance, hit.point.z - platformCheckDistance),1)) {
					if (Physics.CheckSphere (new Vector3 (hit.point.x - platformCheckDistance, hit.point.y - platformHeightDistance, hit.point.z + platformCheckDistance), 1)) {
						return true;
					}
				}
			}
		}
		return false;
	}
		
}
