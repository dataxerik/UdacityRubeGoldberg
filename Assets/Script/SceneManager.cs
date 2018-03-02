using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {
	Player player;
	StarManager starManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool hasWon(){
		return starManager.hasCollectedAllStars () && player.isPlayerOnPlatform;
	}
}
