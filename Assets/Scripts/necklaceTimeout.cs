using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necklaceTimeout : MonoBehaviour
{
    public float timeoutDuration = 3.0f;
    Transform spawn;

    Coroutine timeout;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BagrainFloor"))
        {
            spawn = GameObject.Find("NecklaceSpawn").transform;
            StartCoroutine(Timeout());
        }
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeoutDuration);
        transform.position = spawn.position;
        if (timeout != null) StopCoroutine(timeout);
        yield return null;
    }

    public void ClearTimeout()
    {
        if (timeout != null) StopCoroutine(timeout);
    }
}
