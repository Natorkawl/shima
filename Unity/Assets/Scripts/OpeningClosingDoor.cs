﻿using UnityEngine;
using System.Collections;

public class OpeningClosingDoor : MonoBehaviour {

    private bool isOpen;
    public Animation anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animation>();
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayAnim()
    {
        if (isOpen)
        {
            isOpen = false;
            anim.Play("CloseDoor");
        }

        else
        {
            isOpen = true;
            anim.Play("OpenDoor");
        }
    }

    public bool GetStatus()
    {
        return isOpen;
    }
}
