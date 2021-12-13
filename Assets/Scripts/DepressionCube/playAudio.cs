using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    public AudioSource seeBucket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("XRRigCollider"))
        {
            StartCoroutine("playIt");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine("stopIt");
    }

    IEnumerator playIt()
    {
        seeBucket.Play();
        yield return null;
    }

    IEnumerator stopIt()
    {
        seeBucket.Stop();
        yield return null;
    }
}
