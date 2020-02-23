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
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Wall")
        {
            Variables.Object(gameObject).Set("velocityVector", new Vector2 (0,0));
        }
    }
}
