using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpriteDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject adventurer;
    public GameObject npc;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        Debug.Log("Test");
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void OnMouseDown()
    {
        if (this.GetComponent<Renderer>().enabled)
        {
            Debug.Log("yoo");
            TriggerDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(npc.transform.position, adventurer.transform.position) <= 2)
        {
            this.GetComponent<Renderer>().enabled = true;
        } else {
            this.GetComponent<Renderer>().enabled = false;
        }


    }
}
