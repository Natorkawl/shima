﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BAddFurniture : MonoBehaviour {

	private BBuildManager bbuildManager = null;

	public void Init(BBuildManager buildManager, string furnitureName, Vector3 position, Transform parent) {
		bbuildManager = buildManager;
		transform.name = furnitureName+"Button";

		Transform buttonText = transform.Find ("Text");
		Text text = buttonText.GetComponent<Text> () as Text;
		text.text = furnitureName;

        transform.SetParent(parent);

		transform.localPosition = position;
		transform.localScale = new Vector3 (5, 22.22f, 1);
	}

	public void AddFurniture() {
		Transform buttonText = transform.Find ("Text");
		Text text = buttonText.GetComponent<Text> () as Text;
		Debug.Log (text.text);

        if (bbuildManager == null)
            bbuildManager = GameObject.Find("MenuButton").GetComponent<BBuildManager>();

        bbuildManager.AddFurniture (text.text);
	}

}