using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class TransporterController : MonoBehaviour
{
    public string destination;

    public bool canTransport = false;

    public void Transport()
    {
        if(canTransport)
        {
            SceneManager.LoadScene(destination, LoadSceneMode.Additive);
        }
    }
}
