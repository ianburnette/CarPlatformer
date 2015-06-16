using UnityEngine;
using System.Collections;

public class ShootControls : MonoBehaviour {

	public Rigidbody spare;
	public bool canShoot, shooting;
	public float shootSpeed, returnSpeed, timeToReturn;
	public float distanceToStop = .1f;
	public Transform shootLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2") && canShoot) {
			spare.velocity = transform.forward * shootSpeed;
			canShoot = false;
			shooting = true;
			//spare.isKinematic = false;
			print ("shoot");
			Invoke ("Return", timeToReturn);
		} if (!shooting) {
			var direction = Vector3.zero;
			if (Vector3.Distance(spare.transform.position, shootLocation.position) > distanceToStop)
			{
				//direction = transform.position - spare.transform.position;
				spare.AddForce((shootLocation.position - spare.transform.position) * returnSpeed);
				//spare.AddRelativeForce(direction.normalized * returnSpeed, ForceMode.Force);
			}
			else if (Vector3.Distance(spare.transform.position, shootLocation.position) <= distanceToStop){
				shooting = false;
				canShoot = true;
				//spare.isKinematic = true;
				spare.transform.position = shootLocation.position;
			}
		} 
		if (Vector3.Distance(spare.transform.position, shootLocation.position) <= distanceToStop){
			//spare.isKinematic = true;
			spare.transform.position = shootLocation.position;
			shooting = false;
			canShoot = true;
		}
	}

	void Return(){
		shooting = false;
	}
}
