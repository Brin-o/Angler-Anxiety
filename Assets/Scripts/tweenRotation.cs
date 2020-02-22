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

    private void Start() {
        DOTween.SetTweensCapacity(500, 50);
    }

    private void FixedUpdate() {
        
        // Če se ne premika dovolj, pusti na miru
        if (rigidbody.velocity.magnitude < minVelocity)
            return;
        
        // Updated v Macros\lookAtVelocityHelpet
        // Vsako 1 časovno enoto se sem vpiše vektor hitrosti
        targetVector = (Vector2)Variables.Object(gameObject).Get("targetAngles");

        // Kot med hitrostjo in vertikalo
        angle = Vector2.SignedAngle (Vector2.up, targetVector);

        // Določi če naj se nagne gor al dol
        if (angle > 15)
            angle = 15;
        if (angle < -50)
            angle = -50;

        // 
        var tarVector = new Vector3 (transform.position.x, transform.position.z, angle);

        // Počasi rotiraj proti temu vektorju
        transform.DORotate(tarVector, rotationTimer).SetUpdate(UpdateType.Fixed, true);

    }
}
