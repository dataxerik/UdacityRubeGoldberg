using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
	//[SerializeField] private BoxCollider floorCollision;

	[SerializeField] private Player player;

	void OnTriggerEnter(Collider colli) {
		print (colli.gameObject);
		if(colli.gameObject.tag.Equals("Player")) {
			print("The player is on top of me");
			player.isPlayerOnPlatform = false;
		}
	}

	void OnTrigger
}
