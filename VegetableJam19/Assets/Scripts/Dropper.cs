using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour {

	public GameObject drop;
	public float period;
	private float time;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > period) {
			time -= period;
			GameObject.Instantiate(drop, this.transform);
		}
	}
}
