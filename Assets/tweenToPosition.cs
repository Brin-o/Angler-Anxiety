using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Bolt;
using Ludiq;

public class tweenToPosition : MonoBehaviour
{
    [SerializeField] float timeToMove;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = (Vector3)Variables.Object(gameObject).Get("randomVector");
        moveVector = new Vector3 (moveVector.x, moveVector.y, 0f);
        transform.DOMove(moveVector, timeToMove);
    }
}
