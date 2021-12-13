using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject NPC;
    Animator animator;
    int count = 0;
    public AudioSource playOnAwake;
    public AudioSource npc;
    public AudioSource npcReply;

    private void Awake()
    {
        playOnAwake.Play();
        animator = NPC.GetComponent<Animator>();
    }

    private void Start()
    {
        // find by tag the scene with a tag and set load to true when user is done
    }

    private void OnTriggerEnter(Collider other)
    {
        if (count < 1)
        {
            count++;
            animator.SetBool("isTalking", true);
            StartCoroutine("NPCTalking");
            
            //if (other.CompareTag("Bargain"))
            //{
            //    animator.SetBool("isTalking", true);
            //    StartCoroutine("NPCTalking");
            //}
            //count++;
        }
        
    }

    IEnumerator NPCTalking()
    {
        playOnAwake.Stop();
        npc.Play();
        yield return new WaitForSeconds(35);
        animator.SetBool("isTalking", false);
        yield return new WaitForSeconds(1);
        npcReply.Play();
        yield return null;
    }
}
