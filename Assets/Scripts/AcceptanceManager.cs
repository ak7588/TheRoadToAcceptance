using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Linq;

public class AcceptanceManager : MonoBehaviour
{

    public GateController purpleGate;
    public GateController redGate;
    public GateController greenGate;
    public GateController blueGate;
    private bool isPlaying = false;
    public AudioSource speech;
    private int count = 0;

    public GameObject LeftHand;
    public GameObject XRRig;
    public GameObject lookHere;

    public AudioSource ambience;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<XRGrabInteractable>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (redGate.isCompleted && purpleGate.isCompleted && blueGate.isCompleted && greenGate.isCompleted)
        {
            gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    public void LoadScene(SelectEnterEventArgs args)
    {
        if (args.interactor.gameObject.CompareTag("Hand"))
        {
            StartCoroutine(LoadGrave());
        }
    }

    IEnumerator LoadGrave()
    {
        if (count == 0)
        {
            SceneManager.LoadScene("Acceptance", LoadSceneMode.Additive);
            count += 1;
        }
        yield return StartCoroutine(OnMonologueStart());
        yield return StartCoroutine(UnloadOther());
    }

    IEnumerator UnloadOther()
    {
        AsyncOperation anger = SceneManager.UnloadSceneAsync("AngerScene");
        AsyncOperation denial = SceneManager.UnloadSceneAsync("DenialScene");
        AsyncOperation bargain = SceneManager.UnloadSceneAsync("BargainScene");
        AsyncOperation depression = SceneManager.UnloadSceneAsync("DepressionScene");
        while(!anger.isDone || !denial.isDone || !bargain.isDone || !depression.isDone)
        {
            yield return null;
        }
    }

    IEnumerator OnMonologueStart()
    {
        if (!isPlaying)
        { 
            ambience.Stop();
            speech.Play();
            isPlaying = true;
            XRRig.transform.position = lookHere.transform.position;
            XRRig.transform.rotation = lookHere.transform.rotation;
            GameObject.Find("XR Rig").GetComponent<LocomotionSystem>().enabled = false;
            GameObject.Find("XR Rig").GetComponent<TeleportationProvider>().enabled = false;
            GameObject.Find("XR Rig").GetComponent<SnapTurnProviderBase>().enabled = false;
            LeftHand.GetComponent<XRInteractorLineVisual>().enabled = false;

            yield return new WaitForSeconds(65);
            GameObject.Find("XR Rig").GetComponent<LocomotionSystem>().enabled = true;
            GameObject.Find("XR Rig").GetComponent<TeleportationProvider>().enabled = true;
            GameObject.Find("XR Rig").GetComponent<SnapTurnProviderBase>().enabled = true;
            LeftHand.GetComponent<XRInteractorLineVisual>().enabled = true;
            yield return null;
        }
    }
}
