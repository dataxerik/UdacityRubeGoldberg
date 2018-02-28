using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

	private Star[] stars;
	private int remainingStars;

	// Use this for initialization
	void Start () {
		stars = GetComponentsInChildren<Star> ();
		remainingStars = stars.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DecrementStarCountEvent(Star star){
		Debug.Log ("Current star count is " + remainingStars);
		remainingStars--;
		Debug.Log ("Current star count is " + remainingStars);
	}
		
}
