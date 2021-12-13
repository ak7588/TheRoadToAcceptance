using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationAreasController : MonoBehaviour
{
    public GameObject Area1;
    public GameObject Area2;

    // Start is called before the first frame update
    void Start()
    {
        Area1.SetActive(false);
        Area2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GlassBox3") == null)
        {
            Area1.SetActive(true);
        }
        if (GameObject.Find("GlassBox2") == null)
        {
            Area2.SetActive(true);
        }
    }

}
