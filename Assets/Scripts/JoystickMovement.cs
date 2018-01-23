using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Documentation located:
// https://docs.unity3d.com/Manual/OculusControllers.html

public class JoystickMovement : MonoBehaviour {
	public float speedModifier;
	void Update () {
    // Returns a list of potential joystick names
    Debug.log(UnityEngine.Input.GetJoystickNames());
	}
}
