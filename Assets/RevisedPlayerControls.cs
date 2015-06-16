using UnityEngine;
using System.Collections;

public class RevisedPlayerControls : MonoBehaviour {

	CharacterController controller;
	float h, v;
	Vector3 moveDirection, forward, right;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		moveDirection = Vector3.zero;
		forward = Vector3.zero;
		right = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		forward = transform.forward;
		right = new Vector3 (forward.z, 0, -forward.x);
		GetInput ();
		Vector3 targetDirection = h * right + v * forward;
		moveDirection = Vector3.RotateTowards (moveDirection, targetDirection, 200 * Mathf.Deg2Rad * Time.deltaTime, 1000);

		Vector3 movement = moveDirection * Time.deltaTime * 2;
		controller.Move (movement);
		if (targetDirection != Vector3.zero)
		{
			//transform.rotation = Quaternion.LookRotation(moveDirection);
		}
	}

	void GetInput(){
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
	}
}
