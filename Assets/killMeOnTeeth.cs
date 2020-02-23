using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMeOnTeeth : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("teeth"))
        {
            Destroy(gameObject);
        }
    }
}
