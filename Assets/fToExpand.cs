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

    private void Start() {
        light1.SetActive(true);
        light2.SetActive(false);
        light3.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Make light bigger");
            if(currentLevel == 1)
            {
                light1.SetActive(false);
                light2.SetActive(true);
                music.clipNum = 2;
            }
            if(currentLevel == 3)
            {
                return;
            }
           
            

        }
    }
}
