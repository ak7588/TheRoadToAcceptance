using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoPlayer : MonoBehaviour
{
    public GameObject videoPlay;
    public int timeToStop;

    void Start()
    {
        videoPlay.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "XRRigCollider")
        {

            videoPlay.SetActive(true);
            Destroy(videoPlay, timeToStop);
        }

    }
}
