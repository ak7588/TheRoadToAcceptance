using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterController : MonoBehaviour
{

    public GameObject brokenBox;
    public float force = 1.0f;
    //protected Rigidbody rb;
    private int active = 0;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "bat" && active == 0)
        {
            var rb = collision.collider.gameObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude > force)
            {
                active++;
                go = Instantiate(brokenBox, transform.position, transform.rotation);
                rb.AddExplosionForce(10f, Vector3.zero, 0f);
                Vector3 pos = transform.parent.position;
                pos.y = -30;
                transform.parent.position = pos;
                Destroy(go, 3.0f);
                Destroy(transform.parent.gameObject, 3.25f);
            }
        }

    }

}
