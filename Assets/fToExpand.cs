using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fToExpand : MonoBehaviour
{
    Light lt;
    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Make light bigger");
        }
    }
}
