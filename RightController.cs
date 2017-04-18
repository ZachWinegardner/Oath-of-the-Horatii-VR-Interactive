using UnityEngine;
using System.Collections;

public class RightController : MonoBehaviour {
 
	//these create variables for the buttons defined in the vr script and bools to see when pressed
	//Need to be static so other scripts can see their status
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip; 
	public static bool LgripButtonUp = false; 
	public static bool LgripButtonDown = false; 
	public static bool LgripButtonHeld = false;
	public static bool RgripButtonUp = false; 
	public static bool RgripButtonDown = false; 
	public static bool RgripButtonHeld = false;


	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; 
	public static bool LtriggerButtonUp = false; 
	public static bool LtriggerButtonDown = false; 
	public static bool LtriggerButtonHeld = false;
	public static bool RtriggerButtonUp = false; 
	public static bool RtriggerButtonDown = false; 
	public static bool RtriggerButtonHeld = false;

	private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_Axis0; 
	public static bool Rtouchpadheld = false; 

	private SteamVR_TrackedObject objtracked; 

	//this will go into the VR script and find the index of the device being used
	private SteamVR_Controller.Device controller  { get { return SteamVR_Controller.Input ((int)objtracked.index); } }
	//private SteamVR_Controller.Device Lcontroller { get { return SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost)); } }
	//private SteamVR_Controller.Device Rcontroller { get { return SteamVR_Controller.Input (SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost)); } } 

	public bool CanPickUp = false; 
	public static bool GrippingObject = false; 
	public GameObject LightPointer; 



	void Start () {
		objtracked = GetComponent<SteamVR_TrackedObject> (); 
	}

	void Update () {
		if (controller == null) {
			Debug.Log ("Controller not initialized"); 
			return; 
		}
//
	
//		//takes all those variables and checks every frame if we are pressing them or not, then sets the bool
//		LgripButtonUp = Lcontroller.GetPressUp (gripButton);
//		LgripButtonDown = Lcontroller.GetPressDown (gripButton);
//		LgripButtonHeld = Lcontroller.GetPress (gripButton);
		RgripButtonUp = controller.GetPressUp (gripButton);
		RgripButtonDown = controller.GetPressDown (gripButton);
		RgripButtonHeld = controller.GetPress (gripButton);


		Rtouchpadheld = controller.GetTouch (touchpad);   

//		LtriggerButtonUp = Lcontroller.GetPressUp (triggerButton);
//		LtriggerButtonDown = Lcontroller.GetPressDown (triggerButton);
//		LtriggerButtonHeld= Lcontroller.GetPress (triggerButton);
		RtriggerButtonUp = controller.GetPressUp (triggerButton);
		RtriggerButtonDown = controller.GetPressDown (triggerButton);
		RtriggerButtonHeld= controller.GetPress (triggerButton);

		//this sees if the grip is being held and it currently has a child, so if youre holding something, avoid picking up more than one thing
		if ((!RgripButtonHeld)  && this.transform.FindChild ("pickup")) {
			this.transform.FindChild ("pickup").parent = null; 
			LightPointer.SendMessage ("RotationUpdate"); 
			GrippingObject = false; 
		}

//		if (RgripButtonDown == true)
//			print ("R hand Grip"); 

	}


	// this checks if you are within the trigger, checks if the object is grabable then if you are holding the grip, sets it as a child
	void OnTriggerStay (Collider other){
		if (other.gameObject.CompareTag ("Node") && !GrippingObject) { 
			//Debug.Log ("you can pick this up"); 
			 
			if (RgripButtonHeld==true) {
				other.transform.parent = this.transform;
				other.gameObject.name = "pickup";
				GrippingObject = true; 
				//Debug.Log ("you are holding this object");
				} 
				

		}
			
	}



	

}
