using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

	public float converyorBeltSpeed = .1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision col)
	{
		print ("You're on the belt");
		//transform.forward
		print(transform.forward);
		col.transform.position += new Vector3(0, 0, 1f) * converyorBeltSpeed * Time.deltaTime;

	}
}
