using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnLook : MonoBehaviour
{
    public bool isInDenialScene = false;

    public void onLookDestroy()
    {
        StartCoroutine(DestroyGem());
    }

    IEnumerator DestroyGem()
    {
        if (isInDenialScene && this)
        {
            Destroy(GameObject.Find("PurpleJewelOriginal"), 0.5f);
        }
        yield return null;
    }
}
