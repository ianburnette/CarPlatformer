using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TargetingScript : MonoBehaviour {

	public Transform camera;
	public List<Transform> targetList;
	public int maxTargets;
	public Collider targetTrigger;
	public GameObject crosshairPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			if (!targetTrigger.enabled){
				targetTrigger.enabled = true;
				targetTrigger.transform.GetComponent<MeshRenderer>().enabled = true;
			}
		}
		else{
			if (targetTrigger.enabled){
				targetTrigger.enabled = false;
				targetTrigger.transform.GetComponent<MeshRenderer>().enabled = false;
			}
		}
		if (Input.GetButtonUp ("Fire1")) {
			PurgeList();
		}
	}

	void PurgeList(){
		foreach (Transform currentlyTargetEnemy in targetList) {
			Destroy (currentlyTargetEnemy.gameObject);
		}
		targetList.Clear ();
	}

	void OnTriggerEnter(Collider col){
		bool alreadyPresent = false;
		foreach (Transform currentlyTargetEnemy in targetList) {
			if (col.transform == currentlyTargetEnemy){
				print ("found enemy in list");
				alreadyPresent = true;
			}
		}
		if (!alreadyPresent && targetList.Count<maxTargets) {
			print ("not found, adding to list");
			targetList.Add (col.transform);
			GameObject newCrosshair = (GameObject)Instantiate(crosshairPrefab, col.transform.position, Quaternion.identity);
			newCrosshair.transform.parent = col.transform;
			newCrosshair.GetComponent<LookAtCamera>().target = camera;
		}
	}
}
