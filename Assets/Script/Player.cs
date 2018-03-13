using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool isPlayerOnPlatform { get; set; }
	public StarManager startManager;

	// Use this for initialization
	void Start () {
		isPlayerOnPlatform = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(){
		
	}
		
}
