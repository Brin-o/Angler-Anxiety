using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fToExpand : MonoBehaviour
{
    [SerializeField]GameObject light1;
    [SerializeField]GameObject light2;
    [SerializeField]GameObject light3;
    int currentLevel = 1;
    [SerializeField]musicWrangler music;
    [SerializeField] GameObject crabHappy;
    [SerializeField] GameObject crabSad;
    [SerializeField] GameObject firstWall;
    [SerializeField] GameObject secondWall;
    GameObject[] listVreck;


    private void Start() {
        light1.SetActive(true);
        light2.SetActive(false);
        light3.SetActive(false);
    }
    void Update()
    {
        listVreck = GameObject.FindGameObjectsWithTag("Vrecka");
        var stevilkaVreck = listVreck.Length;

        
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Make light bigger");
            if(currentLevel == 1)
            {
                light1.SetActive(false);
                light2.SetActive(true);
                music.clipNum = 2;
                crabHappy.SetActive(true);
                crabSad.SetActive(false);
                firstWall.SetActive(false);
                
            }
        }
    }
}
