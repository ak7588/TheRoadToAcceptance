using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SaveCamera saved = FindObjectOfType<SaveCamera>();
        saved.DoneWithCamera();
    }

}
