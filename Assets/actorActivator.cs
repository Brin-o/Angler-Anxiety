using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actorActivator : MonoBehaviour
{
    public dialogueList ActorToActivate;
    public string textToDisplay = ".. Press the left mouse button to talk ..";
    public GameObject text;
    public setCurrentTexts dialogueMachine;
 
    private void Start() {
        dialogueMachine.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            dialogueMachine.gameObject.SetActive(true);
            ActorToActivate.gameObject.SetActive(true);
            ActorToActivate.GetComponent<dialogueList>().initDialogue();
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerjeNot");
            text.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player je sel ven iz active raidusa");
            dialogueMachine.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
        }
    }


    
}
