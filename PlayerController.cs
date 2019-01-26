using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//private Collider2D MainCol,JumpCol;
	private Rigidbody2D RB;
	
	public float MaxSpeed,JumpForce;
	public float JumpDelay;
	public float JumpElapsed;
    public bool notInDialogue;

	private int touching;

	// Use this for initialization
	void Start () {
        notInDialogue = true;
		JumpElapsed = 0;
		touching = 0;
		//MainCol = GetComponents<Collider2D>()[0];
		//JumpCol = GetComponents<Collider2D>()[0];
		RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (notInDialogue) 
        {
		JumpElapsed += Time.deltaTime;
		JumpElapsed = Mathf.Clamp(JumpElapsed, 0, 2);
		float hzin = Input.GetAxis("Horizontal");
		this.transform.Translate(new Vector3(MaxSpeed*hzin, 0.0f, 0.0f));
		if (touching > 0 && JumpElapsed > JumpDelay && Input.GetAxis("Jump") > 0.5) {
			RB.AddForce(new Vector2(0.0f, JumpForce));
			JumpElapsed = 0;
            }
		}

	}

	private void OnTriggerEnter2D(Collider2D collision) {
		touching++;
		Debug.Log(touching);
	}
	private void OnTriggerExit2D(Collider2D collision) {
		touching--;
		Debug.Log(touching);
	}
}
