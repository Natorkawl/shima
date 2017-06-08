﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BMenuManager : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject buildPanel;
	public GameObject roomPanel;
	public GameObject furniturePanel;
	public GameObject sensorPanel;
	public GameObject accuatorPanel;
	public GameObject binarySensorPanel;
	public GameObject furnitureScrollView;

	public void Menu() {
		if (menuPanel != null)
			menuPanel.SetActive (!menuPanel.activeInHierarchy);
		ShowBuildMenu (false);
		ShowRoomMenu (false);
		ShowSensorMenu (false);
		ShowAccuatorMenu (false);
		ShowBinaryMenu (false);
		ShowFurniturePanelMenu (false);
	}

	public void Build() {
		if (buildPanel != null) {
			buildPanel.SetActive (!buildPanel.activeInHierarchy);
		}
	}

	public void Accuator() {
		if (roomPanel != null) {
			ShowRoomMenu (false);
			ShowSensorMenu (false);
			ShowAccuatorMenu (!accuatorPanel.activeInHierarchy);
		}
	}

	public void Room() {
		if (roomPanel != null) {
			ShowRoomMenu (!roomPanel.activeInHierarchy);
			ShowSensorMenu (false);
			ShowAccuatorMenu (false);
		}
	}

	public void Sensor() {
		if (sensorPanel != null) {
			ShowRoomMenu (false);
			ShowSensorMenu (!sensorPanel.activeInHierarchy);
			ShowAccuatorMenu (false);
		}
	}

	public void Furniture() {
		if (furniturePanel != null) {
			furniturePanel.SetActive (!furniturePanel.activeInHierarchy);
		}
	}

	public void BinarySensor() {
		if (binarySensorPanel != null) {
			binarySensorPanel.SetActive (!binarySensorPanel.activeInHierarchy);
		}
	}

	// Use this for initialization
	void Start () {
		Object[] furnitures = Resources.LoadAll ("Furniture");
		GameObject furnitureButton;
		BAddFurniture bAddFurniture;
		BBuildManager bBuildManager = GetComponent<BBuildManager> ();
		int x = -920;
		int y = 640;
		foreach (GameObject g in furnitures) {
			furnitureButton = Instantiate (Resources.Load ("UI/FurnitureButton")) as GameObject;
			bAddFurniture = furnitureButton.GetComponent<BAddFurniture> ();
			bAddFurniture.Init (bBuildManager, g.name, new Vector3 (x, y, 0), furnitureScrollView.transform);
			x += 496;
			if (x >= 840) {
				x = -920;
				y -= 726;
			}
		}
		ShowBuildMenu (false);
		ShowRoomMenu (false);
		ShowSensorMenu (false);
		ShowAccuatorMenu (false);
		ShowBinaryMenu (false);
		ShowFurniturePanelMenu (false);
//		Transform furnitureButton = furnitureScrollView.transform.Find ("FurnitureButton");
//		furnitureButton.transform.name = furnitures [0].name+"Button";
//		Transform buttonText = furnitureButton.Find ("Text");
//		Text text = buttonText.GetComponent<Text> () as Text;
//		text.text = furnitures [0].name;

//		foreach(GameObject g in Resources.LoadAll("Furniture")){
//			Debug.Log (g.name);
//
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void ShowBuildMenu(bool value) {
		if (buildPanel != null)
			buildPanel.SetActive (value);
	}

	private void ShowRoomMenu(bool value) {
		if (roomPanel != null)
			roomPanel.SetActive (value);
	}

	private void ShowSensorMenu(bool value) {
		if (sensorPanel != null)
			sensorPanel.SetActive (value);
	}

	private void ShowAccuatorMenu(bool value) {
		if (accuatorPanel != null)
			accuatorPanel.SetActive (value);
	}

	private void ShowBinaryMenu(bool value) {
		if (binarySensorPanel != null)
			binarySensorPanel.SetActive (value);
	}

	private void ShowFurniturePanelMenu(bool value) {
		if (furniturePanel != null)
			furniturePanel.SetActive (value);
	}

}