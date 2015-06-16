using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerStickToGround : MonoBehaviour {

	ThirdPersonCharacter controlScript;
	public LayerMask mask;
	public float gravityModifier, playerOffset;
	Rigidbody rb;
	public Vector3 collisionPoint;
	CapsuleCollider coll;
	bool jumping;

	// Use this for initialization
	void Start () {
		controlScript = GetComponent<ThirdPersonCharacter> ();
		rb = GetComponent<Rigidbody> ();
		coll = GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		//rb.AddForce (-Vector3.up * gravityModifier * Time.deltaTime);
		jumping = controlScript.jumping;
		if (!jumping) {
			StickToGround ();
		}


	}

	void StickToGround(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, mask)){
			collisionPoint = hit.point;
			transform.position = collisionPoint;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawSphere (collisionPoint, .2f);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere (transform.position, .2f);
	}
}