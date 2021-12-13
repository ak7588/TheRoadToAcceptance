using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whiteAudio : MonoBehaviour
{
    public AudioSource cantGrab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            StartCoroutine("playIt");
        }
    }

    IEnumerator playIt()
    {
        cantGrab.Play();
        yield return new WaitForSeconds(6);
    }
}
