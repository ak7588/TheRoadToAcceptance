using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckingContainerManager : MonoBehaviour
{
    public Material right, wrong, defaultMaterial;
    public GameObject container;
    private GameObject[] fakesArray;
    private int numTotal = 8;
    private int visible = 4;
    Coroutine checker;

    public AudioSource playOnAwake;
    public AudioSource completedAudio;
    public AudioSource wrong1;
    public AudioSource wrong2;
    public AudioSource wrong3;
    public AudioSource wrong4;
    int audioCounter = 1;

    private void Awake()
    {
        if (GameObject.Find("PurpleJewelOriginal") != null)
        {
            Destroy(GameObject.Find("PurpleJewelOriginal"), 1.0f);
        }
        fakesArray = new GameObject[numTotal];
        for (int i = 0; i < numTotal; i++)
        {
            GameObject obj = GameObject.Find("FakePedestal" + i);
            if (i > 3)
            {
                obj.SetActive(false);
            }
            if(obj != null)
                fakesArray[i] = obj;
        }
        playOnAwake.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RealGem"))
        {
            Destroy(other.gameObject, 1);
            gameObject.GetComponent<MeshRenderer>().material = right;
            GameObject.Find("gatePurple").GetComponent<GateController>().isCompleted = true; // check if completed
            StartCoroutine("playAudio");
            
        }
        else if (other.gameObject.CompareTag("Denial") || other.gameObject.CompareTag("Bargain") || other.gameObject.CompareTag("Depression") || other.gameObject.CompareTag("Acceptance") || other.gameObject.CompareTag("Anger"))
        {
            gameObject.GetComponent<MeshRenderer>().material = wrong;
            //StartCoroutine(InvokeCoroutine(other.gameObject));
            //StartCoroutine("LoadNext");
            checker = StartCoroutine(LoadNext(other.gameObject));
        }
    }

    //IEnumerator InvokeCoroutine(GameObject other)
    //{
    //    yield return new WaitForSeconds(1);
    //    other.SetActive(false);
    //    container.GetComponent<MeshRenderer>().material = defaultMaterial;
    //    yield return null;

    //}

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(checker);
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    IEnumerator LoadNext(GameObject other) {
        yield return new WaitForSeconds(1);
        other.SetActive(false);
        container.GetComponent<MeshRenderer>().material = defaultMaterial;

        if (audioCounter == 1)
        {
            playOnAwake.Stop();
            wrong1.Play();
            audioCounter++;
        }
        else if (audioCounter == 2)
        {
            wrong2.Play();
            audioCounter++;
        }
        else if (audioCounter == 3)
        {
            wrong3.Play();
            audioCounter++;
        }
        else if (audioCounter == 4)
        {
            wrong4.Play();
            audioCounter = 1;
        }

        //GameObject lastElement = fakesArray[fakesArray.Length - 1];
        //lastElement.SetActive(true);
        fakesArray[visible].SetActive(true);
        //oneToShow--;
        visible++;
        //fakesArray = fakesArray.Take(fakesArray.Length - 1).ToArray();

        List<int> active = new List<int>();

        Debug.Log("getting random index");

        int index = 0;
        foreach (var fake in fakesArray) {
            if (fake.GetComponentInChildren<XRGrabInteractable>(true).gameObject.activeInHierarchy) active.Add(index);
            ++index;
        }

        Debug.Log("setting gems");

        if (visible == 8 && active.Count == 1)
        {
            Debug.Log("setting last gem");
            GameObject obj = fakesArray[active[0]].GetComponentInChildren<XRGrabInteractable>(true).gameObject;
            obj.tag = "RealGem";
            //obj.GetComponentInChildren<MeshRenderer>().material = right;
        }
        else
        {
            int random = Random.Range(0, active.Count);
            //do
            //{
            //    random = Random.Range(0, visible);
            //} while (!fakesArray[random].activeSelf);

            for(int i = 0; i < active.Count; ++i)
            {
                Debug.Log("active" + i + ": " + active[i]);
            }
            for (int i = 0; i < fakesArray.Length; ++i)
            {
                Debug.Log("fake" + i + ": " + (fakesArray[i] != null ? fakesArray[i].name : "null"));
            }
            Debug.Log("visible: " + visible + ", random: " + random + ", chosen: " + active[random]);

            for (int i = 0; i < visible; i++)
            {
                if (i == active[random])
                {
                    Debug.Log("setting correct gem to index: " + active[random]);

                    //fakesArray[i].transform.GetChild(2).tag = "RealGem";
                    //fakesArray[i].transform.GetChild(2).GetComponentInChildren<MeshRenderer>().material = right;

                    XRGrabInteractable obj = fakesArray[i].GetComponentInChildren<XRGrabInteractable>();

                    if(obj == null)
                    {
                        Debug.LogError("chosen active index was NULL!");
                    }
                    else
                    {
                        obj.gameObject.tag = "RealGem";
                        //obj.gameObject.GetComponentInChildren<MeshRenderer>().material = right;
                    }
                }
                else
                {
                    Debug.Log("setting incorrect gem to index: " + i);

                    //fakesArray[i].transform.GetChild(2).tag = "Denial";
                    //fakesArray[i].transform.GetChild(2).GetComponentInChildren<MeshRenderer>().material = defaultMaterial;

                    XRGrabInteractable obj = fakesArray[i].GetComponentInChildren<XRGrabInteractable>();

                    if (obj == null)
                    {
                        Debug.Log("incorrect index was NULL!");
                    }
                    else
                    { 
                        obj.gameObject.tag = "Denial";
                        //obj.gameObject.GetComponentInChildren<MeshRenderer>().material = defaultMaterial;
                    }

                }

            }
        }

    
        
        
        yield return null;
    }

    IEnumerator playAudio()
    {
        completedAudio.Play();
        yield return null;
    }
}
