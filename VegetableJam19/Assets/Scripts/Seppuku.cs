using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seppuku : MonoBehaviour {

	public float alivetime;
	private float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= alivetime) GameObject.Destroy(this.gameObject);
	}
}
