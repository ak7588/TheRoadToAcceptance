using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{

    // Update is called once per frame
    void Start()
    {
        if (GameObject.Find("Ring") != null)
        {
            Destroy(GetComponent<BoxCollider>());
        }
    }



    void Update()
    {
        if (GameObject.Find("Ring") != null)
        {
            Destroy(GetComponent<BoxCollider>());
        }
    }

}
