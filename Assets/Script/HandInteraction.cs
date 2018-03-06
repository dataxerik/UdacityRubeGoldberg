using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteraction : MonoBehaviour {
	public SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;

	public float throwForce = 1.5f;

    public ObjectMenuManager objectMenuManager;
    //Swipe
    public float swipeSum, touchLast, touchCurrent, distance;
    public bool hasSwipedLeft, hasSwipedRight;
	private const string throwableTagLabel = TagList.ballTag;


	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);
        if(device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
        }
        if(device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            distance = touchCurrent - touchLast;
            touchLast = touchCurrent;
            swipeSum += distance;

            if(!hasSwipedRight && swipeSum > 0.5f)
            {
                swipeSum = 0;
                SwipedRight();
                hasSwipedRight = false;
                hasSwipedLeft = true;
            }
            if (!hasSwipedLeft && swipeSum < -0.5f)
            {
                swipeSum = 0;
                SwipedLeft();
                hasSwipedRight = true;
                hasSwipedLeft = false;
            }
        }

        if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            swipeSum = 0;
            touchCurrent = 0;
            touchLast = 0;
            hasSwipedRight = false;
            hasSwipedLeft = false;
        }

        if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            SpawnObject();
        }
	}

    void SpawnObject()
    {
        objectMenuManager.SpawnCurrentObject();
    }

    void SwipedLeft()
    {
        objectMenuManager.MenuLeft();
        //Debug.Log("SwipeLeft);
    }

    void SwipedRight()
    {
        objectMenuManager.MenuRight();
        //Debug.Log("SwipeLeft);
    }

    void OnTriggerStay(Collider coli)
	{
        print("Trigger Activate");
		if (coli.gameObject.CompareTag (throwableTagLabel)) {
            print("Hi");
			if (device.GetPressUp (SteamVR_Controller.ButtonMask.Trigger)) {
				ThrowObject (coli);
			} else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
				GrabObject (coli);
			}
		}
	}

	void GrabObject(Collider coli){
		coli.transform.SetParent (gameObject.transform);
		coli.GetComponent<Rigidbody> ().isKinematic = true;
		device.TriggerHapticPulse (2000);
		Debug.Log ("You are touching down the trigger on an object.");
	}

	void ThrowObject(Collider coli){
		coli.transform.SetParent (null);
		Rigidbody rigidBody = coli.GetComponent<Rigidbody> ();
		rigidBody.isKinematic = false;
		rigidBody.velocity = device.velocity * throwForce;
		rigidBody.angularVelocity = device.angularVelocity;
		Debug.Log ("You have released the trigger.");
	}

}
