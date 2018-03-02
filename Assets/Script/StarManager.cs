using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour {

	private Star[] stars;
	private int remainingStars;
	public Player player;

	// Use this for initialization
	void Start () {
		stars = GetComponentsInChildren<Star> ();
		remainingStars = stars.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.isPlayerOnPlatform) {
			EnableAllStars ();
		}
	}

	void DecrementStarCountEvent(){
		Debug.Log ("Current star count is " + remainingStars);
		remainingStars--;
		Debug.Log ("Current star count is " + remainingStars);
	}

	void EnableAllStars() {
		for (int i = 0; i < stars.Length; i++) {
			stars [i].Enable ();
		}
		remainingStars = stars.Length;
	}


	void OnEnable(){
		Star.OnEnter += DecrementStarCountEvent;
	}

	void OnDisable(){
		Star.OnEnter -= DecrementStarCountEvent;
	}

	public bool hasCollectedAllStars() {
		return remainingStars == 0;
	}
}
