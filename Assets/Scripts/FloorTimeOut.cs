using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTimeOut : MonoBehaviour
{
    public float timeoutDuration = 3.0f;
    public Transform spawn;

    Coroutine timeout;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(Timeout());
        }

        if (collision.gameObject.CompareTag("DenialFloor"))
        {
            StartCoroutine(Timeout());
        }

        if (collision.gameObject.CompareTag("DepressionFloor"))
        {
            spawn = GameObject.Find("SpawnLocation").transform;
            StartCoroutine(Timeout());
        }

        if (collision.gameObject.CompareTag("AngerFloor"))
        {
            spawn = GameObject.Find("AngerSpawnGem").transform;
            StartCoroutine(Timeout());
        }

        if (collision.gameObject.CompareTag("BagrainFloor"))
        {
            spawn = GameObject.Find("BrgainSpawnGem").transform;
            StartCoroutine(Timeout());
        }

    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timeoutDuration);
        transform.position = spawn.position;
    }

    public void ClearTimeout()
    {
        if (timeout != null) StopCoroutine(timeout);
    }
}
