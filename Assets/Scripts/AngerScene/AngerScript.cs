using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerScript : MonoBehaviour
{
    public Material right, wrong, defaultMaterial;
    public GameObject container;

    public AudioSource completedAudio;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anger"))
        {
            Destroy(other.gameObject, 1);
            gameObject.GetComponent<MeshRenderer>().material = right;
            GameObject.Find("gateRed").GetComponent<GateController>().isCompleted = true; // check if completed
            StartCoroutine("playAudio");
        }
        else if(other.gameObject.CompareTag("Bargain") || other.gameObject.CompareTag("Denial") || other.gameObject.CompareTag("Depression") || other.gameObject.CompareTag("Acceptance"))
        {
            gameObject.GetComponent<MeshRenderer>().material = wrong;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
    }
    IEnumerator playAudio()
    {
        completedAudio.Play();
        yield return null;
    }

}
