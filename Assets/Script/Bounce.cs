using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	private const string bounceTagLabel = "Bounce";
	private Rigidbody rb;
	public float heightForce;
	private const float forceMulitplier = 6f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate(){
		//rb.velocity = Vector3.ClampMagnitude (rb.velocity, 12);
		if (rb.velocity.magnitude > 12f) {
			print ("Slow down!");
			float dragForce = (rb.velocity.magnitude - 12f) / rb.velocity.magnitude;
			print (-1 * rb.velocity * dragForce);
			rb.AddForce (-1 * rb.velocity * dragForce);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		print ("hi");
		if (col.gameObject.CompareTag (bounceTagLabel)) {
			print ("this has the label");
			print (rb.velocity);
			print (rb.velocity.magnitude);
			//rb.AddForce (transform.up * forceMulitplier);
			//rb.AddForce (-1 * rb.velocity * forceMulitplier);
			//rb.AddForce (transform.up * forceMulitplier, ForceMode.Impulse);
			rb.AddForce (col.transform.forward * forceMulitplier, ForceMode.Impulse);
			/*
			if (rb.velocity.magnitude > 12f) {
				print ("Slow down!");
				float dragForce = (rb.velocity.magnitude - 12f) / rb.velocity.magnitude;
				print (-1 * rb.velocity * dragForce);
				rb.AddForce (-1 * rb.velocity * dragForce);
			}*/
			//rb.AddForce (rb.velocity * forceMulitplier);
			print(rb.velocity);
		}
	}

}
