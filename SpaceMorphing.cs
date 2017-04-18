using UnityEngine;
using System.Collections;

public class SpaceMorphing : MonoBehaviour {
	


	private SkinnedMeshRenderer BlendShapes; 
	public float CeilingHeight = 0f; 
	public float RoomDepth = 0f; 
	public GameObject HandleSwitch; 
	private Vector3 HandleYstart;
	public Vector3 Updown; 
	private Vector3 HandleZstart;
	public Vector3 Forward; 
	public Vector3 Back; 
	public float HandleSensitivity= 10f; 
	public float BSW1;
	public float BSW2;
	public float BSW3;
	public float Morph1;
	public float Morph2;
	public float Morph3;


	void Start () {
		
		BlendShapes = this.GetComponent<SkinnedMeshRenderer> (); 
		//Get the current weight of the B shapes and set them to the variables
		BSW1 = BlendShapes.GetBlendShapeWeight (0);
		BSW2 = BlendShapes.GetBlendShapeWeight (1);
		BSW3 = BlendShapes.GetBlendShapeWeight (2);

	}

	void Update () {



		//Store Controller Position----------------------------------------------------------
		// sees if trigger was pressed, then sets the HandleSwitch V3 as the position of the ball at that time
		if (LeftController.LtriggerButtonDown == true) {
			HandleYstart = new Vector3 (0f, HandleSwitch.transform.position.y, 0f);
			HandleZstart = new Vector3 (0f, 0f, HandleSwitch.transform.position.z); 
		}

		//Compare the movement of controller------------------------------------------------
		// sets these variables as the current position minus the stored position
		if (LeftController.LtriggerButtonHeld == true){
			
			//compare the position
			Updown = new Vector3 (0f, (HandleSwitch.transform.position.y-HandleYstart.y), 0f); 
			Forward = new Vector3 (0f, 0f, (HandleSwitch.transform.position.z-HandleZstart.z));
			Back = new Vector3 (0f, 0f, (HandleZstart.z-HandleSwitch.transform.position.z));

			//Tell the BS weights
			Morph1 = (BSW1+(Updown.y*HandleSensitivity)); 
			Morph2 = (BSW2+(Forward.z*HandleSensitivity)/2f); 
			Morph3 = (BSW3+(Back.z*HandleSensitivity)*1.5f); 
	
		}

		if (LeftController.LtriggerButtonUp == true) {
			BSW1 = BlendShapes.GetBlendShapeWeight (0);
			BSW2 = BlendShapes.GetBlendShapeWeight (1);
			BSW3 = BlendShapes.GetBlendShapeWeight (2);
		}

		// Move Ceiling ----------------------------------------------
		BlendShapes.SetBlendShapeWeight (0, (Morph1));

		// Move Depth ----------------------------------------------
		BlendShapes.SetBlendShapeWeight (1, (Morph2));
		BlendShapes.SetBlendShapeWeight (2, (Morph3));


	

	




		// Old controls, use arrowkeys to move ----------------------
//		if (Input.GetKey (KeyCode.UpArrow) && CeilingHeight<100f) {
//			CeilingHeight += 0.1f; 
//			BlendShapes.SetBlendShapeWeight (0, CeilingHeight); 
//		}
//
//		if (Input.GetKey (KeyCode.DownArrow) && CeilingHeight>0f) {
//			CeilingHeight -= 0.1f; 
//			BlendShapes.SetBlendShapeWeight (0, CeilingHeight); 
//		}


//		if (Input.GetKey (KeyCode.LeftArrow) && RoomDepth<100f) {
//			RoomDepth += 0.1f; 
//			BlendShapes.SetBlendShapeWeight (1, RoomDepth); 
//		}
//
//		if (Input.GetKey (KeyCode.RightArrow) && RoomDepth>0f) {
//			RoomDepth -= 0.1f; 
//			BlendShapes.SetBlendShapeWeight (1, RoomDepth); 
//		}
		//----------------------------------------------------------

	}
}
