using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{

    public float thrust = 0.3f;
    public float backwardThrust = -0.3f;
    public float strafeThrust = 0.3f;
    private bool holdingThrustButton;
    private bool holdingInverseThrustButton;
    public GameObject cameraRig;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = cameraRig.GetComponent<Rigidbody>();
        holdingInverseThrustButton = holdingThrustButton = false;
       
        
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(OVRInput.Get(OVRInput.RawAxis2D.RThumbstick));
        JetpackController();
    }

    void JetpackController()
    {

        if (OVRInput.GetDown(OVRInput.RawButton.X))
            rigidbody.angularVelocity = Vector3.zero;
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            holdingThrustButton = true;
        if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
            holdingThrustButton = false;
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
            holdingInverseThrustButton = true;
        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
            holdingInverseThrustButton = false;


        if (holdingThrustButton)
            rigidbody.AddForce(transform.forward* thrust);
        if (holdingInverseThrustButton)
        {
            var velocity = rigidbody.velocity;
            velocity.x = SlowDownAxis(velocity.x);
            velocity.y = SlowDownAxis(velocity.y);
            velocity.z = SlowDownAxis(velocity.z);
            rigidbody.velocity = velocity;

        }

    }

    public float SlowDownAxis(float axis)
    {
        if (axis > 0.1f)
            return axis - backwardThrust;
        else if (axis < -0.1f)
            return axis + backwardThrust;
        else
            return 0;
    }
}
