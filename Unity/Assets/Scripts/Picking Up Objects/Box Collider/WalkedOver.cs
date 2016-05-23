﻿using UnityEngine;
using System.Collections;

public class WalkedOver : MonoBehaviour {
    
    public PickUp pickUpScript = null;
    private GameObject walkedOver;

	void Start () {
        initPickUpScript();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Floor" && other.gameObject.tag != "Fixed")
        {
            if (walkedOver == null)
            {
                if (pickUpScript != null)
                {
                    pickUpScript.AddWalkedOverObject(other.gameObject, other.tag);
                    walkedOver = other.gameObject;
                }

                else
                    initPickUpScript();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Debug.Log("TriggerExit with" + other.gameObject);

        if (other.gameObject == walkedOver)
        {
            Debug.Log("TriggerExit effectue");
            pickUpScript.AddWalkedOverObject(null, null);
            walkedOver = null;
        }
    }

    void initPickUpScript() {
        pickUpScript = GetComponentInParent<PickUp>();
    }
}
