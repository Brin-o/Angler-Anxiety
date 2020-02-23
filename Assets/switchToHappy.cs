using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchToHappy : MonoBehaviour
{
    [SerializeField] SpriteRenderer happySprite;
    void crabNowHappy()
    {
        happySprite.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
