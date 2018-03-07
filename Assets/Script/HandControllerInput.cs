using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControllerInput : MonoBehaviour {

	public SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	private LineRenderer laser;
	public LineRenderer laser1;
	public GameObject teleportAimerObject;
	public Vector3 teleportLocation;
	public GameObject player;
	public LayerMask laserMask;

	private float yNudgeAmt = 1f; //specific to teleportAimerObject Height
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		laser = GetComponentInChildren<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);

		if (device.GetPress (SteamVR_Controller.ButtonMask.Trigger)) {
			laser.gameObject.SetActive (true);
			teleportAimerObject.gameObject.SetActive (true);

			laser.SetPosition (0, gameObject.transform.position);

			RaycastHit hit;

			if (Physics.Raycast (transform.position, transform.forward, out hit, 15, laserMask)) {
				teleportLocation = hit.point;
				laser.SetPosition (1, teleportLocation);
				laser1.SetPosition (0, laser.GetPosition(1));
				print ("laser at 1 is " + laser.GetPosition (1));
				print ("laser1 at 0 is " + laser.GetPosition (0));
				//aimer position
				teleportAimerObject.transform.position = new Vector3 (teleportLocation.x, teleportLocation.y + yNudgeAmt, teleportLocation.z);
			} else {
				teleportLocation = new Vector3 (transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.forward.y, transform.forward.z * 15 + transform.forward.z);
				RaycastHit groundRay;
				if (Physics.Raycast (teleportLocation, -Vector3.up, out groundRay, 17, laserMask)) {
					laser1.SetPosition (1, groundRay.point);
					teleportLocation = new Vector3 (transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 + transform.forward.y, transform.forward.z * 15 + transform.forward.z);
				}
				laser.SetPosition (1, transform.forward * 15 + transform.position);
				teleportAimerObject.transform.position = teleportLocation + new Vector3 (0, yNudgeAmt, 0);
			}
		
		}

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
			laser.gameObject.SetActive (false);
			teleportAimerObject.gameObject.SetActive (false);
			player.transform.position = teleportLocation;
		}
	}
}
