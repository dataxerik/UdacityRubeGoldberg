using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
	public bool isCaptured { get; private set; }
	private MeshRenderer starRender;
	private const string ballTag = TagList.ballTag;
	public delegate void OnBallEnter();
	public static event OnBallEnter OnEnter;

	// Use this for initialization
	void Start () {
		starRender = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Wait(){
		print (Time.time);
		yield return new WaitForSeconds (10);
		Enable ();
		print (Time.time);
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag(ballTag)) {
			Debug.Log ("Entering a star");
			Disable ();
			if (OnEnter != null) {
				OnEnter ();
			}
		}
	}

	void Disable() {
		Debug.Log ("Turning the star off");
		starRender.enabled = false;
		isCaptured = true;
	}

	public void Enable() {
		Debug.Log ("Turning the star on");
		starRender.enabled = true;
		isCaptured = false;
	}
		
}
