using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobble : MonoBehaviour {

	public float Height;
	public float Period;
	public float time;
	public AnimationCurve AC;
	public Vector3 initPos;

	// Use this for initialization
	void Start () {
		initPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		this.transform.position = initPos + new Vector3(0.0f, AC.Evaluate(time/Period) * Height, 0.0f);
		if (time > Period) time -= Period;
	}
}
