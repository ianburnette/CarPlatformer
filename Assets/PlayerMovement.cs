using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	Rigidbody rb;
	public float rotateSpeed;
	Vector3 target;
	Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerInput(float h, float v){

		Vector3 verticalVelocity = v * transform.forward;
		Vector3 horizontalVelocity = h * transform.right;

		verticalVelocity *= speed * Time.deltaTime;
		horizontalVelocity *= speed * Time.deltaTime;

		//rb.velocity = verticalVelocity + horizontalVelocity;

		
		Vector3 forward = transform.forward;
		Vector3 right = new Vector3(forward.z, 0, -forward.x);

		Vector3 targetDirection = h * right + v * forward;	
		
		moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 200 * Mathf.Deg2Rad * Time.deltaTime, 1000);
		
		var movement = moveDirection  * Time.deltaTime * speed;
	//	controller.Move(movement);
		rb.velocity = movement;
		transform.rotation = Quaternion.LookRotation(movement);
	}
}
