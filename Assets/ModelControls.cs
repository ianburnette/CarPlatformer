using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class ModelControls : MonoBehaviour {

	public Transform carModel;
	ThirdPersonCharacter controlScript;
	public float turnSpeed, rightSelfSpeed;
	Rigidbody rb;
	public float verticalOffset;
	public LayerMask groundMask;
	public float lowerMax, upperMin;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		controlScript = GetComponent<ThirdPersonCharacter> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetPosition ();
		SetRotation ();
	//	PreventTipping ();
	}

	void SetPosition(){
		//if (!controlScript.jumping) {
		//	carModel.position = new Vector3 (transform.position.x, transform.position.y+ verticalOffset, transform.position.z);
		//} else {
			carModel.position = new Vector3 (transform.position.x, transform.position.y + verticalOffset, transform.position.z);
		//}
	}

	void SetRotation(){
//		RaycastHit hit;
//		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 2f, groundMask)){
//			carModel.rotation = Quaternion.FromToRotation(Vector3.right, hit.normal);
//		}

//		Vector3 beforeRotation = carModel.rotation.eulerAngles;
//		Vector3 newRotation = new Vector3 (carModel.rotation.eulerAngles.x, Mathf.Lerp (carModel.rotation.eulerAngles.y, transform.rotation.eulerAngles.y, turnSpeed * Time.deltaTime), carModel.rotation.eulerAngles.z);
//		carModel.rotation = Quaternion.Euler (newRotation);//.eulerAngles = newRotation;


		carModel.rotation = Quaternion.Lerp (carModel.rotation, transform.rotation, turnSpeed);

//		carModel.eulerAngles = new Vector3 
//						(carModel.rotation.eulerAngles.x, 
//						 Mathf.Lerp (carModel.rotation.eulerAngles.y, transform.rotation.eulerAngles.y, turnSpeed * Time.deltaTime), 
//						 carModel.rotation.eulerAngles.z);

//		carModel.eulerAngles = new Vector3 
//			(carModel.rotation.eulerAngles.x, 
//			 Mathf.Lerp (carModel.rotation.eulerAngles.y, transform.rotation.eulerAngles.y, turnSpeed * Time.deltaTime), 
//			 carModel.rotation.eulerAngles.z);
	//	Vector3 tempRotation = carModel.rotation.eulerAngles;
	//	carModel.rotation = Quaternion.RotateTowards(carModel.rotation, Quaternion.LookRotation(rb.velocity, Vector3.up), Time.deltaTime * turnSpeed);
	//	carModel.rotation = Quaternion.Euler (tempRotation.x, carModel.rotation.eulerAngles.y, tempRotation.z);
	}

	void PreventTipping(){
		float zValue = carModel.rotation.eulerAngles.z;
		if (zValue > lowerMax && zValue < 180f) { // rotateBackTowardCenter
			//carModel.rotation = Quaternion.Euler(carModel.rotation.eulerAngles.x, carModel.rotation.eulerAngles.y, lowerMax);// Mathf.Lerp (carModel.rotation.eulerAngles.z, 0f, rightSelfSpeed * Time.deltaTime));
		} else if (zValue < upperMin && zValue >= 180f) { //rotateBackTowardCenter
			//carModel.rotation = Quaternion.Euler(carModel.rotation.eulerAngles.x, carModel.rotation.eulerAngles.y, upperMin);//Mathf.Lerp (carModel.rotation.eulerAngles.z, 0f, rightSelfSpeed * Time.deltaTime));
		}
	}
}


//transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rigidbody.velocity, Vector3.up), Time.deltaTime * 10f);