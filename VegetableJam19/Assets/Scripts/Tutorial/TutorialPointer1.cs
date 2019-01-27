using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPointer1 : MonoBehaviour {

	public PotsController PotsC;
	public Seppuku Katana;
	public SpriteRenderer SR;

	// Use this for initialization
	void Start () {
		SR = GetComponent<SpriteRenderer>();
		Katana = GetComponent<Seppuku>();
	}
	
	// Update is called once per frame
	void Update () {
		if(PotsC.unlocked == 2) {
			Katana.enabled = true;
			SR.enabled = true;
		}
	}
}
