using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithObjects : MonoBehaviour {

	public float offset;
	private GameObject collidedObject;
    private Rigidbody collidedRigidbody;
	private bool holding;
    private FixedJoint fixedJoint;
    private bool touching;
    public float deadZoneTime;
    private float bufferTime;
    private Rigidbody rigidbody;


    private void Start(){
        fixedJoint = GetComponent<FixedJoint>();
        touching = false;
        holding = false;
        rigidbody = GetComponentInParent<Rigidbody>();
    }
    void Update () {
        
        if (touching && !holding){
            if (OVRInput.GetDown(OVRInput.RawButton.A)){
                GrabObject();
            }
        }
		else if (holding) {
		    if (OVRInput.GetDown (OVRInput.RawButton.A)) {
		 		LetGo ();
			}
		}
			Debug.Log(rigidbody.velocity);
	}

	void OnCollisionEnter(Collision collision){
        touching = true;
        collidedObject = collision.gameObject;
        bufferTime = Time.realtimeSinceStartup + deadZoneTime;
	}

    void OnCollisionExit(Collision collision){
        if(!holding)
            touching = Time.realtimeSinceStartup > bufferTime;
    }

    void LetGo(){
		holding = false;
        touching = false;
        fixedJoint.connectedBody = null;
        collidedObject.GetComponent<Collider>().enabled = true;
        collidedRigidbody.AddForce(rigidbody.velocity);
        Debug.Log(rigidbody.velocity);
    }

	void GrabObject(){
        holding = true;
        collidedRigidbody = collidedObject.GetComponent<Rigidbody>();
        collidedObject.GetComponent<Collider>().enabled = false;
        fixedJoint.connectedBody = collidedRigidbody;
	}
}
