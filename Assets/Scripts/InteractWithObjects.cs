using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour {

	public float offset;
	private GameObject collidedObject;
	private GameObject newObjectOrigin;
	private bool holding;
	void Update () {
		if (holding) {
			collidedObject.transform.position = new Vector3(newObjectOrigin.transform.position.x,newObjectOrigin.transform.position.y,newObjectOrigin.transform.position.z);
			collidedObject.transform.eulerAngles = newObjectOrigin.transform.eulerAngles; 
			if (OVRInput.GetDown (OVRInput.RawButton.A)) {
				LetGo ();
				GetComponent<Collider> ().enabled = true;
			}
		}
			
	}

	void OnCollisionStay(Collision collision){
		if (OVRInput.GetDown (OVRInput.RawButton.A)) {
			GrabObject (collision);
		}
	}

	void LetGo(){
		collidedObject.GetComponent<Rigidbody> ().useGravity = true;
		collidedObject.GetComponent<Collider> ().enabled = true;
		holding = false;
		GetComponent<Collider> ().enabled = false;
		Destroy (newObjectOrigin);

	}

	void GrabObject(Collision collision){
		collidedObject = collision.gameObject;
		collidedObject.GetComponent<Rigidbody> ().useGravity = false;
		collidedObject.GetComponent<Collider> ().enabled = false;
		holding = true;
		newObjectOrigin = new GameObject ("ObjectPivot");
		newObjectOrigin.transform.SetParent (gameObject.transform);
		newObjectOrigin.transform.eulerAngles = transform.eulerAngles;
		newObjectOrigin.transform.localPosition = new Vector3(0, 0, offset);
	}
}
