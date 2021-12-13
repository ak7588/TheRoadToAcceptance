using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public GameObject container;
    public AudioSource plinthAppear;

    // Start is called before the first frame update
    void Start()
    {
        container.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ring"))
        {
            container.SetActive(true);
            StartCoroutine("playAudio");

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Ring"))
        {
            container.SetActive(false);
            StartCoroutine("stopAudio");
        }
    }

    IEnumerator playAudio()
    {
        plinthAppear.Play();
        yield return null;
    }

    IEnumerator stopAudio()
    {
        plinthAppear.Stop();
        yield return null;
    }
}
