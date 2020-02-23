using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
using DG.Tweening;

public class exposePlayerDistance : MonoBehaviour
{

    public static float playerDistance;
    void Update()
    {
        playerDistance = (float)Variables.Object(gameObject).Get("distanceFromStart");
    }
}
