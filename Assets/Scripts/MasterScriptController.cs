using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScriptManager : MonoBehaviour
{
    private static MasterScriptManager _instance;

    public static MasterScriptManager Instance { get { return _instance; } }

    public bool isAngerCompleted = false;
    public bool isDenialCompleted = false;
    public bool isDepressionCompleted = false;
    public bool isBargainCompleted = false;

    public GameObject denialGem;
    public GameObject depressionGem;
    public GameObject angerGem;
    public GameObject bargainGem;

    public Material grayMaterial;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        depressionGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
        angerGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
        bargainGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
        // acceptanceGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
    }

    private void Update()
    {
        if (!isDenialCompleted)
        {
            // depressionGem.XRGrabInteractable = false;
            angerGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
            bargainGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
        }
        else
        {
            angerGem.transform.GetChild(0).GetComponent<MeshRenderer>().material = grayMaterial;
        }

        if (!isAngerCompleted)
        {
            // have all gems grayed out except anger
        }
        else
        {
            // activate bargain
        }

        if (!isBargainCompleted)
        {
            // have all gems grayed out except bargain
        }
        else
        {
            // activate depression
        }

        if (!isDepressionCompleted)
        {
            // have all gems grayed out except depression
        }

        if (isDenialCompleted && isAngerCompleted && isBargainCompleted && isDepressionCompleted)
        {
            // activate the acceptance scene
        }
    }
}