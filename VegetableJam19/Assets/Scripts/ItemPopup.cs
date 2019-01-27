using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{

	private Camera cam;
	private PlayerController PC;

	public float Height;
    public Text titleText,popupText;
	public Image Img;
	public float flyTime;
	public float stayTime;
    public AnimationCurve flyIn;
	public float timeElapsed;

	public string title;
	public string words;
	public Sprite Sp;

    private float timing;

    // Start is called before the first frame update
    void Start()
    {
		cam = Camera.main;
		PC = cam.GetComponent<CameraController>().Player.GetComponent<PlayerController>();
		timeElapsed = 0;
		titleText.text = title;
		popupText.text = words;
		Img.sprite = Sp;
        //words = new Queue<char>();
		//title = new Queue<char>();
	}

    // Update is called once per frame
    void Update(){
		timeElapsed += Time.deltaTime;
		if (timeElapsed > flyTime + stayTime + flyTime) {
			GameObject.Destroy(this.gameObject);
			PC.freeze = false;
		} else if (timeElapsed < flyTime) {
			PC.freeze = true;
			this.transform.position = cam.transform.position - new Vector3(0.0f, flyIn.Evaluate(timeElapsed / flyTime) * Height, -10.0f);
		} else if (timeElapsed > flyTime + stayTime) {
			this.transform.position = cam.transform.position + new Vector3(0.0f, Height - flyIn.Evaluate((timeElapsed - flyTime - stayTime) / flyTime) * Height, 10.0f);
		}/* else {
			if (title.Count > 0) {
				titleText.text += " " + title.Dequeue();
			} else if (words.Count > 0) {
				popupText.text += " " + words.Dequeue();
			}
		}*/
    }
}
