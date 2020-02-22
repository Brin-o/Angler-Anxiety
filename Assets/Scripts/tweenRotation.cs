using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Ludiq;
using Bolt;

public class tweenRotation : MonoBehaviour
{
    [SerializeField] Vector2 targetVector = new Vector3 (1, 2);
    [SerializeField] float rotationTimer = 3f;
    [SerializeField] Rigidbody2D rigidbody = default;
    [SerializeField] float minVelocity = 0.1f;
    public float angle;

    private void FixedUpdate() {
        
        if (rigidbody.velocity.magnitude < minVelocity)
            return;
        
        targetVector = (Vector2)Variables.Object(gameObject).Get("targetAngles");
        angle = Vector2.SignedAngle (Vector2.up, targetVector);

        if (angle > 15)
            angle = 15;
        if (angle < -50)
            angle = -50;


        var tarVector = new Vector3 (transform.position.x, transform.position.z, angle);
        transform.DORotate(tarVector, rotationTimer).SetUpdate(UpdateType.Fixed, true);

    }
}
