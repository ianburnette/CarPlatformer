using UnityEngine;
using System.Collections;

public class spareCollision : MonoBehaviour {

	public float knockbackAmt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
		if (coll.transform.tag == "enemy") {
			HitEnemy(coll.transform);
		//	print (coll.relativeVelocity);
		}
	}

	void HitEnemy(Transform enemyHit){
		enemyHit.GetComponent<NavMeshAgent> ().enabled = false;
		enemyHit.GetComponent<enemyFollow> ().enabled = false;
		Rigidbody rb = enemyHit.GetComponent<Rigidbody> ();
		rb.isKinematic = false;
		rb.AddForce (enemyHit.position - transform.position * knockbackAmt, ForceMode.Impulse);
		enemyHit.GetComponent<EnemyBehavior> ().Hit ();
	}
}
