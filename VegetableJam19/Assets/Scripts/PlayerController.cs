using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//private Collider2D MainCol,JumpCol;
	private Rigidbody2D RB;

	public bool freeze;

	public int Size;
	public float[] MaxSpeed,JumpForce;
	public float JumpDelay;
	public Animator animator;
	public float JumpElapsed;

	private int touching;
	public bool facingLeft;

	// Use this for initialization
	void Start () {
		freeze = false;
		JumpElapsed = 0;
		touching = 0;
		//MainCol = GetComponents<Collider2D>()[0];
		//JumpCol = GetComponents<Collider2D>()[0];
		RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		JumpElapsed += Time.deltaTime;

		if (JumpElapsed >= 0.5f) {
			JumpElapsed = 0.5f;
			animator.SetBool("Is_Fall", true);
			animator.SetBool("Is_Jump", false);
		} else {
			animator.SetBool("Is_Fall", false);
		}

		if (!freeze) {
			float hzin = Input.GetAxis("Horizontal");
			animator.SetFloat("Speed", Mathf.Abs(hzin));

			this.transform.Translate(new Vector3(MaxSpeed[Size] * hzin, 0.0f, 0.0f));
			if (touching > 0 && JumpElapsed > JumpDelay && Input.GetAxis("Jump") > 0.5) {
				RB.AddForce(new Vector2(0.0f, JumpForce[Size]));
				JumpElapsed = 0;
			}

			if (hzin > 0.1 && facingLeft) {
				facingLeft = false;
				this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1.0f);
			} else if (hzin < -0.1 && !facingLeft) {
				facingLeft = true;
				this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, 1.0f);
			}
		}

		if (touching > 0) {
			animator.SetBool("Is_Fall", false);
			animator.SetBool("Is_Jump", false);
		} else {
			if (!animator.GetBool("Is_Fall")) animator.SetBool("Is_Jump", true);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		touching++;
		//Debug.Log(touching);
	}
	private void OnTriggerExit2D(Collider2D collision) {
		touching--;
		//Debug.Log(touching);
	}

	public void SizeChange(int i) {
		Size = i;
	}
}
