using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float stunTime, destroyTime;
	Rigidbody rb;
	NavMeshAgent nav;
	public int health;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hit(){
		if (health > 0) {
			Invoke ("GetUp", stunTime);
			health--;
		}else{
			Invoke("DestroySelf", destroyTime);
		}
	}

	void GetUp(){
		rb.isKinematic = true;
		transform.rotation = Quaternion.identity;
		nav.enabled = true;
		GetComponent<enemyFollow> ().enabled = true;
	}

	void DestroySelf(){
		Destroy (gameObject);
	}
}
