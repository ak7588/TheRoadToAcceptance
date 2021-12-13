using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class staffScript : MonoBehaviour
{
    AudioSource awakeAudio;

    private void Awake()
    {
        awakeAudio.Play();
        //StartCoroutine(UnloadIntro());
    }

    //IEnumerator UnloadIntro()
    //{
    //    AsyncOperation unload = SceneManager.UnloadSceneAsync("intro");
    //    while(!unload.isDone)
    //    {
    //        yield return null;
    //    }
    //}
}
