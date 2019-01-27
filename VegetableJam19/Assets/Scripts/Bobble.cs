using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobble : MonoBehaviour {

	public float Height;
	public float Width;
	public float Period;
	public float time;
	public AnimationCurve AC;
	public Vector3 initPos;
	public bool anchor;

	// Use this for initialization
	void Start () {
		if (!anchor) initPos = this.transform.position;
		else initPos = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (!anchor) this.transform.position = initPos + new Vector3(AC.Evaluate(time / Period) * Width, AC.Evaluate(time / Period) * Height, 0.0f);
		else this.transform.localPosition = initPos + new Vector3(AC.Evaluate(time / Period) * Width, AC.Evaluate(time / Period) * Height, 0.0f);
		if (time > Period) time -= Period;
	}
}
