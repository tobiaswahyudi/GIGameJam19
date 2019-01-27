using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{

    public Text popupText;

    public Animator animate;

    private float timing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowDialogue(string texts)
    {
        timing = Time.time;

        animate.SetBool("isOpen", true);

        popupText.text = texts;

    }


    // Update is called once per frame
    void Update()
    {
        while (animate.GetBool("isOpen")) {
            if ( (Time.time - timing)> 1.5) {
                animate.SetBool("isOpen", false);
            }
        }
    }
}
