using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		GameObject other = collision.gameObject;
		Platform plt = other.GetComponent<Platform>();
		if(plt != null) {
			if (plt.Penetrate) {
				other.GetComponent<Collider2D>().enabled = false;
			}
		}
	}
}
