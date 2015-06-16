using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	float h, v;
	PlayerMovement movementScript;

	// Use this for initialization
	void Start () {
		movementScript = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		movementScript.PlayerInput (h, v);
	}
}
