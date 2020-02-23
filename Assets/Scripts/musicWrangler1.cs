using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicWrangler1 : MonoBehaviour
{
    public List<AudioClip> audioClips; // = new List<AudioClip>();
    public List<AudioClip> transitionClips;
    AudioSource musicSource;
    AudioSource transitionSource;
    AudioClip nextClip;

    //[Range(0,4)]
    public int clipNum = 0;

    int playingClipNum = 0;
    bool isTransitioningOut = false;


    // Start is called before the first frame update
    void Start()
    {
        var sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        transitionSource = sources[1];

        //musicSource.loop = true;

        StartCoroutine(follower());
    }

    IEnumerator follower()
    {
        Debug.Log("[MUSIC] Starting music coroutine");
        musicSource.clip = audioClips[0];

        while (true)
        {
            Debug.Log("[MUSIC] (playing " + playingClipNum + " next " + clipNum + ")");

            // Če je treba spremenit clip
            if (clipNum != playingClipNum)
            {
                if (playingClipNum > transitionClips.Count)
                    break;

                Debug.Log("[MUSIC] Loading transition " + playingClipNum);
                isTransitioningOut = true;
                transitionSource.clip = transitionClips[playingClipNum];

                Debug.Log("[MUSIC] Waiting end of loop");
                yield return new WaitWhile(() => musicSource.isPlaying);

                Debug.Log("[MUSIC] Going to transition");
                musicSource.Stop();
                transitionSource.Play();

                playingClipNum = clipNum;

                yield return new WaitForSeconds(transitionSource.clip.length * .90f);
            } else
            // Ni treba spremenit clipa
            {
                // Je treba it iz transition -> loop
                if (isTransitioningOut)
                {
                    if (clipNum > audioClips.Count)
                        break;

                    Debug.Log("[MUSIC] Loading loop " + clipNum);
                    isTransitioningOut = false;
                    musicSource.clip = audioClips[clipNum];

                    Debug.Log("[MUSIC] Waiting end of transition");
                    yield return new WaitWhile(() => transitionSource.isPlaying);

                    Debug.Log("[MUSIC] Going to loop");
                    musicSource.Play();
                    transitionSource.Stop();
                    

                    yield return new WaitForSeconds(musicSource.clip.length * .90f);
                } else
                // Loop
                {
                    yield return new WaitWhile(() => musicSource.isPlaying);

                    Debug.Log("[MUSIC] Ponavljam clip " + playingClipNum);
                    musicSource.clip = audioClips[clipNum];
                    musicSource.Play();

                    Debug.Log("[MUSIC] Waiting end of loop");
                    yield return new WaitForSeconds(musicSource.clip.length * .90f);
                    //yield return new WaitWhile(() => musicSource.isPlaying);
                }
            }

            

            //Debug.Log("[MUSIC]   Čakam na konec predvajanja " + audio.clip.name);
            //yield return new WaitForSeconds(audio.clip.length*.90f);
            //Debug.Log("[MUSIC]       Predviden konec ");
            //yield return new WaitWhile( () => audio.isPlaying );
            //Debug.Log("[MUSIC]       Actual konec");
        }
        Debug.Log("[MUSIC] Done");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
