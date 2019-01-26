using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour
{

    public Text popupText;

    public Animator animate;

    private Queue<string> words;

    private float timing;

    // Start is called before the first frame update
    void Start()
    {
        words = new Queue<string>();
        
    }

    public void ShowDialogue(Dialogue texts)
    {
        timing = Time.time;

        animate.SetBool("isOpen", true);

        words.Clear();

        foreach (string sentence in texts.sentences)
        {
            words.Enqueue(sentence);
        }

        popupText.text = words.Dequeue();


        
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
