using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainScript : MonoBehaviour
{
    public Material right, wrong, defaultMaterial;
    public GameObject container;
    public GameObject greenGate;
    public AudioSource completeAudio;

    private void Start()
    {
        // greenGate = GameObject.Find("gateGreen").transform.GetChild(5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bargain"))
        {
            Destroy(other.gameObject, 1);
            gameObject.GetComponent<MeshRenderer>().material = right;
            GameObject.Find("gateGreen").transform.GetChild(5).GetComponent<LoadScene>().canUnload = true;
            GameObject.Find("gateGreen").GetComponent<GateController>().isCompleted = true; // check if completed
            StartCoroutine("PlayAudio");

        }
        else if (other.gameObject.CompareTag("Anger") || other.gameObject.CompareTag("Denial") || other.gameObject.CompareTag("Depression") || other.gameObject.CompareTag("Acceptance"))
        {
            gameObject.GetComponent<MeshRenderer>().material = wrong;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    IEnumerator PlayAudio()
    {
        completeAudio.Play();
        yield return null;
    }
}
