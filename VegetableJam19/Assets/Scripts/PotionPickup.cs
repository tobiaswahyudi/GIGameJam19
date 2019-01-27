using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickup : MonoBehaviour {

	public Transform Cursor;
	public PotsController PotC;
	public Transform Player;
	public GameObject Popup;
	public float pickupDist;
	public float clickDist;
	public string itemName;
	public string description;
	public GameObject pop;

	private SpriteRenderer pointingArrow;

	// Use this for initialization
	void Start() {
		Player = Camera.main.GetComponent<CameraController>().Player;
		pointingArrow = GetComponentsInChildren<SpriteRenderer>()[1];
	}

	// Update is called once per frame
	void Update() {
		if (Vector3.Distance(Player.transform.position, this.transform.position) < pickupDist) {
			pointingArrow.enabled = true;
			if (Input.GetMouseButtonDown(0) && Mathf.Abs(Cursor.transform.position.x - this.transform.position.x) < clickDist) {
				PotC.unlockNextPot();
				pop = Instantiate(Popup);
				ItemPopup IP = pop.GetComponent<ItemPopup>();
				IP.title = itemName;
				IP.words = description;
				IP.Sp = GetComponent<SpriteRenderer>().sprite;
				/*
				for (int i = 0; i < itemName.Length; i++) {
					Debug.Log(itemName[i]);
					IP.title.Enqueue(itemName[i]);
				}
				for (int i = 0; i < description.Length; i++) {
					Debug.Log(description[i]);
					IP.words.Enqueue(description[i]);
				}
				Debug.Log("SEPPUKU");
				*/
				GameObject.Destroy(this.gameObject);
			}
		} else {
			pointingArrow.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
