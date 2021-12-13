using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class endingTransition : MonoBehaviour
{
    public string tag1;
    //public GameObject gem;
    public float speed;
    //public string destination;
    //public TransporterController ctrl;

    public string scene;

    //Color color;
    float f = 1;


    // Start is called before the first frame update
    //void Awake()
    //{
    //    color = gem.GetComponent<Renderer>().material.color;

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tag1))
        {
            StartCoroutine(GemGlow());
        }

        //Transport();
        
        
    }

    IEnumerator GemGlow()
    {

        while(f < 10000)
        {
            GameObject.Find("WhiteJewel").transform.GetChild(0).GetComponent<Renderer>().material.SetFloat("_Emission", f);

            f = Mathf.MoveTowards(f, 10000, speed*Time.deltaTime);
            yield return null;
        }

        if (f >= 10000)
        {
            XRSceneTransitionManager.Instance.TransitionTo(scene);

        }

    }

    //public void Transport()
    //{
    //    if (canTransport)
    //    {
    //        XRSceneTransitionManager.Instance.TransitionTo(destination);
    //        SceneManager.LoadScene(destination, LoadSceneMode.Additive);
    //    }
    //}


}
