using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class pushPlayerBack : MonoBehaviour
{
    [SerializeField] Vector3 pushBack;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        other.transform.DOMove(other.transform.position + pushBack, 1f);
    }
}
