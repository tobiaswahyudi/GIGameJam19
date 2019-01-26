using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public Transform Player;
	public float pickupDist;
	public string objectName;
	public string objectID;

	private GameObject pointingArrow;

	// Use this for initialization
	void Start () {
		Player = Camera.main.GetComponent<CameraController>().Player;
		pointingArrow = GetComponentInChildren<Bobble>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(Player.transform.position.x - this.transform.position.x) < pickupDist) {
			pointingArrow.GetComponent<SpriteRenderer>().enabled = true;
		} else {
			pointingArrow.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
