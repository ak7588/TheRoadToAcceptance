using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public void Save()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void DoneWithCamera()
    {
        Destroy(gameObject);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        XRSceneTransitionManager.Instance.saveMe = this;
    }
}
