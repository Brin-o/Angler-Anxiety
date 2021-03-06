﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 viewPortSize;
    Camera cam;

    public float viewPortFactor;

    Vector3 targetPosition;
    private Vector3 currentVelocity;
    public float followDuration;
    public float maximumFollowSpeed;

    public Transform player;

    Vector2 distance;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        targetPosition = player.position;
    }   

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            viewPortSize = (cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - cam.ScreenToWorldPoint(Vector2.zero)) * viewPortFactor;

            if(player)distance = player.position - transform.position;
            if(Mathf.Abs(distance.x) > viewPortSize.x /2){
                targetPosition.x = 0;
            }
            if(Mathf.Abs(distance.y) > viewPortSize.y /2){
                targetPosition.y = player.position.y - (viewPortSize.y / 2 * Mathf.Sign(distance.y));
            }

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition - new Vector3 (0,0,10), ref currentVelocity, followDuration, maximumFollowSpeed);
        }
    }

    void OnDrawGizmos() {
        Color c = Color.green;
        c.a = 0.5f;
        Gizmos.color = c;

        Gizmos.DrawCube(transform.position, viewPortSize);
    }
}
