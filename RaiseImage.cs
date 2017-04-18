using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseImage : MonoBehaviour {
	//This checks if you are touching the thumb pad on the Vive controller, and then checks local euler angles if they are rotated 
	// as if you are checking a watch. This will show an image plane parented to the controller
	
	
	public Transform RHand; 
	private Vector3 RCZ; 

	
	void Start () {

	}
	
	void Update () {

		
		RCZ = RHand.localEulerAngles;

		if (RightController.Rtouchpadheld == true &&RCZ.z>60f &&RCZ.z<100f) {
			this.GetComponent<MeshRenderer> ().enabled = true; 
		} else
			this.GetComponent<MeshRenderer> ().enabled = false; 

	}
}
