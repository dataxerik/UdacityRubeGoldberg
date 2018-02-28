using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision coli){
		print (transform.forward);
		//print (new Vector3 (0, transform.up.y * 10f, 0));
		coli.rigidbody.AddForce (new Vector3 (0,10f, 0) * 12);
	}

	void OnTriggerStay(Collider other){
		Debug.Log ("trigger stay");
		float otherSA = 4 * Mathf.PI * other.transform.GetComponent<SphereCollider> ().radius;
		float distance = Vector3.Distance (this.transform.position, other.transform.position);
		print((1.0f + distance * distance) * otherSA);
		float appliedForce = 1000f / (1.0f + distance * distance) * otherSA;
		//other.attachedRigidbody.AddForce (new Vector3 (0,10f, 0) * 12);
		other.attachedRigidbody.AddForce(transform.forward * appliedForce);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position + transform.up, transform.position + transform.up+new Vector3(0, 10f, 0));
	}
}
