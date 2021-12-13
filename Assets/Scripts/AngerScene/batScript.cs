using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batScript: MonoBehaviour
{
    public AudioSource batAudio;
    public AudioSource playOnAwake;

    private void Awake()
    {
        playOnAwake.Play();
    }

    // Start is called before the first frame update
    public void playBatAudio()
    {
        playOnAwake.Stop();
        batAudio.Play();
    }    
}
