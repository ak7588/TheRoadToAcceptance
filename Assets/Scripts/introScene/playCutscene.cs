using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Linq;


public class playCutscene : MonoBehaviour
{
    public GameObject videoPlay;
    public int timeToStop;
    public GameObject XRrig;
    public GameObject LeftHand;
    public AudioSource ambianceAudio;

    // Start is called before the first frame update
    void Start()
    {
        videoPlay.SetActive(false);
        ambianceAudio.Play();
    }

    public void PlayCutscene()
    {
        videoPlay.SetActive(true);
        ambianceAudio.Stop();
        StartCoroutine("onVideoEndLoad");
    }

    IEnumerator onVideoEndLoad()
    {
        XRrig.GetComponent<LocomotionSystem>().enabled = false;
        XRrig.GetComponent<TeleportationProvider>().enabled = false;
        XRrig.GetComponent<SnapTurnProviderBase>().enabled = false;
        LeftHand.GetComponent<XRInteractorLineVisual>().enabled = false;

        yield return new WaitForSeconds(timeToStop);
        Destroy(videoPlay);
        XRrig.GetComponent<LocomotionSystem>().enabled = true;
        XRrig.GetComponent<TeleportationProvider>().enabled = true;
        XRrig.GetComponent<SnapTurnProviderBase>().enabled = true;
        LeftHand.GetComponent<XRInteractorLineVisual>().enabled = true;

        XRSceneTransitionManager.Instance.TransitionTo("Lobby");
        yield return StartCoroutine(Unload());
    }

    IEnumerator Unload()
    {
        AsyncOperation unload = SceneManager.UnloadSceneAsync("intro");
        while (!unload.isDone)
        {
            yield return null;
        }
    }

}
