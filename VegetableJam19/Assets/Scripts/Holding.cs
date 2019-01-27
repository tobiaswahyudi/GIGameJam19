using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour {

	public SpriteRenderer SR;
	public string HeldItem;
	public GameObject Thing;

	// Use this for initialization
	void Start () {
		SR = this.gameObject.GetComponent<SpriteRenderer>();
		SR.enabled = false;
		HeldItem = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1) && HeldItem != null) DropItem();
	}

	void DropItem() {
		GameObject drop = GameObject.Instantiate(Thing, this.transform.position, Quaternion.identity);
		Pickup P = drop.GetComponent<Pickup>();
		P.itemName = HeldItem;
		HeldItem = null;
		SR.enabled = false;
	}

	void BurnItem() {
		HeldItem = null;
		SR.enabled = false;
	}
}
