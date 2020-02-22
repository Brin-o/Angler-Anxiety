using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using DG.Tweening;

public class setCurrentTexts : MonoBehaviour
{

    public List<string> textQueue;
    public string nameOfCharacter;
    public int dialogueCount;

    [SerializeField] Transform outPos;
    [SerializeField] Transform inPos;
    private Rigidbody2D rigidbody;


    private void Start() {
        dialogueCount = 0;
        transform.position = outPos.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void DialogAdvance()
    {



        if (dialogueCount < textQueue.Count)
        {            
            if(transform.position != inPos.position)
                transform.DOJump(inPos.position, 2f, 1, 0.75f);
            else
                transform.DOShakePosition(1f, 5f, 5, 45f);

            SetNextName(nameOfCharacter);      
            SetNextText(textQueue[dialogueCount]);

            dialogueCount++;
        }
        else
        {
            transform.DOJump(outPos.position, 2f, 1, 0.75f);
            Debug.Log("Prevlki");
            var currentActor = GameObject.FindGameObjectWithTag("Actor");
            currentActor.gameObject.SetActive(false);
            return;
        }



    }

    public void SetNextText(string nextText)
    {
        Variables.Object(gameObject).Set("dialogueCurrentText", nextText);
    }
    public void SetNextName(string nextName)
    {
        Variables.Object(gameObject).Set("dialogueCurrentName", nextName);
    }
}
