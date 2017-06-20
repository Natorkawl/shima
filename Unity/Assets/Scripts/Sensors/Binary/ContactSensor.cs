﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactSensor : IESensor, ISensorObserver {

	public bool state = true;
	public float delay = 1f;
	public string SensorType = "ContactSensor";
	private float currentTime;

	protected override void IESensorInit ()
	{
		base.IESensorInit ();
		ActionableEntity actionableEntity = GetComponent<ActionableEntity> ();
		if (actionableEntity != null) {
			actionableEntity.subscribe (this);
		}
	}

	protected override void IESensorUpdate ()
	{
		base.IESensorUpdate ();
		if(currentTime > 0)
			currentTime -= Time.deltaTime;
	}

	protected override void IESensorStop ()
	{
		base.IESensorStop ();
	}

	void ISensorObserver.Notify (object sender, EventArgs e) {
		if (currentTime <= 0) {
			state = !state;
			currentTime = delay;
			SmartHomeServer.InsertBinarySensorData (name, SensorType, state);
		}
	}

}