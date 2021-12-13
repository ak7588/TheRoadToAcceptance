using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DippingManager : MonoBehaviour
{
    public Material blue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Depression"))
        {
            other.tag = "Pass";
            GameObject.Find("BlueJewel").transform.GetChild(0).GetComponent<MeshRenderer>().material = blue;
        }
    }
}
