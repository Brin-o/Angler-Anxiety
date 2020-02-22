using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;

public class dialogueList : MonoBehaviour
{

    [SerializeField] string nameOfCharacter = "A person";
    public List<string> thingsToSay;
    [SerializeField] setCurrentTexts dialogueController = default;

    void Start()
    {
        dialogueController.dialogueCount = 0;
        dialogueController.textQueue = thingsToSay;
        dialogueController.nameOfCharacter = nameOfCharacter;
    }

}
