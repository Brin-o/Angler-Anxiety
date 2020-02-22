using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ludiq;
using Bolt;


public class chompSound : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var player = animator.gameObject.transform.parent.transform.parent.gameObject;

        var audioListener = player.GetComponent<AudioListener>();
        var audioSource = player.GetComponent<AudioSource>();
        var audioClips = (List<AudioClip>) Variables.Object(player).Get("chomp_sounds");
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();
        //Debug.Log(audioClips);
    }

}
