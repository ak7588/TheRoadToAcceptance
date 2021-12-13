using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLid : MonoBehaviour
{

    public Transform start;
    public Transform end;
    Rigidbody rb;

    public void Slide(float slider)
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        transform.position = Vector3.Lerp(start.position, end.position, slider);
        if (transform.position == end.position)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
