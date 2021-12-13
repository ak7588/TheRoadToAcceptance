using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canva;

    public void Deactivate()
    {
        canva.SetActive(false);
    }
}
