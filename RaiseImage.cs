using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseImage : MonoBehaviour {

	public Transform RHand; 
	private Vector3 RCZ; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		
		RCZ = RHand.localEulerAngles;

		if (RightController.Rtouchpadheld == true &&RCZ.z>60f &&RCZ.z<100f) {
			this.GetComponent<MeshRenderer> ().enabled = true; 
		} else
			this.GetComponent<MeshRenderer> ().enabled = false; 

	}
}
