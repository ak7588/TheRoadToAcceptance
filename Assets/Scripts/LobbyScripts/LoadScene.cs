using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class LoadScene : MonoBehaviour
{
    //public TransporterController ctrl;
    public bool loadScene;
    // public GameObject gate;
    public GameObject OriginalArea;

    public string destination;
    public string tags;
    public string tag2;
    public bool canUnload = true;

    // Start is called before the first frame update
    void Start()
    {
        loadScene = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(tags) && loadScene)
        {

            Scene test = SceneManager.GetSceneByName(destination);
            if (!test.IsValid())
            {
                SceneManager.LoadScene(destination, LoadSceneMode.Additive);
                if (canUnload) OriginalArea.SetActive(false);
            }
            loadScene = false;

        }

        else if (other.gameObject.CompareTag(tag2) && !loadScene)
        {
            if (canUnload)
            {
                SceneManager.UnloadSceneAsync(destination);
                OriginalArea.SetActive(true);
            }
            loadScene = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
       // loadScene = !loadScene;
       //if (loadScene)
            //loadScene = false;
        //SceneManager.UnloadSceneAsync(destination);
    }
}
