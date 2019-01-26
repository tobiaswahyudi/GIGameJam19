using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Player;
	public float CamSpeed;
	public float CamHeight;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Lerp(this.transform.position,Player.transform.position + new Vector3(0 ,CamHeight, -10),
			CamSpeed*(Mathf.Abs(Vector3.Distance(this.transform.position, Player.transform.position))-8.0f));
	}
}
