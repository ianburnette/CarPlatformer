using UnityEngine;
using System.Collections;

public class enemyFollow : MonoBehaviour {

	enemyProperties properties;
	public Transform target;
	public NavMeshAgent nav;

	void Start(){
		properties = GetComponent<enemyProperties> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	// Use this for initialization
	void OnEnable () {
		nav.speed = properties.chaseSpeed;
		nav.destination = target.position;
	}
	
	// Update is called once per frame
	void Update () {
		nav.destination = target.position;
	}
}
