using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTimeOut : MonoBehaviour
{
    public float timeoutDuration = 3.0f;
    public Transform spawn;

    Coroutine timeout;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AngerFloor"))
        {
            StartCoroutine(Timeout());
        }
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeoutDuration);
        transform.position = spawn.position;
        transform.rotation = spawn.rotation;
        if (timeout != null) StopCoroutine(timeout);
        yield return null;
    }

    public void ClearTimeout()
    {
        if (timeout != null) StopCoroutine(timeout);
    }
}
