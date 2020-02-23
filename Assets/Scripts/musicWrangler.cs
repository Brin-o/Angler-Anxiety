using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicWrangler : MonoBehaviour
{
    public List<AudioClip> audioClips;

    [Range(0,2)]
    public int clipNum = 0;

    int playingClipNum = 0;

    AudioSource sourceA, sourceB;
    AudioSource primarySource, secondarySource;

    Coroutine primaryFadeRoutine = null;
    Coroutine secondaryFadeRoutine = null;


    void Start()
    {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();

        sourceA = audioSources[0];
        sourceB = audioSources[1];

        primarySource = sourceA;
        secondarySource = sourceB;

        CrossFade(audioClips[0], .5f, 3);
    }
    

    void Update()
    {
        if (playingClipNum != clipNum)
        {
            CrossFade(audioClips[clipNum], .5f, 5);
            playingClipNum = clipNum;
        }
    }


    public void CrossFade(AudioClip clipToPlay, float maxVolume, float fadingTime, float delay_before_crossFade = 0)
    {
        StartCoroutine(CrossFadeCoroutine(clipToPlay, maxVolume, fadingTime, delay_before_crossFade));
    }


    IEnumerator CrossFadeCoroutine(AudioClip clipToPlay, float maxVolume, float fadingTime, float delay_before_crossFade = 0)
    {
        if (delay_before_crossFade > 0)
        {
            yield return new WaitForSeconds(delay_before_crossFade);
        }

        // Play secondary
        secondarySource.clip = clipToPlay;
        secondarySource.Play();
        secondarySource.volume = 0;

        // Prekini existing fade (just in case)
        if (primaryFadeRoutine != null)
            StopCoroutine(primaryFadeRoutine);
        if (secondaryFadeRoutine != null)
            StopCoroutine(secondaryFadeRoutine);

        // Zaženi fade our primarne in fade in sekundarne
        primaryFadeRoutine = StartCoroutine(FadeSourceCoroutine(primarySource, primarySource.volume, 0, fadingTime));
        secondaryFadeRoutine = StartCoroutine(FadeSourceCoroutine(secondarySource, secondarySource.volume, maxVolume, fadingTime));

        // Swap primary & secondary
        var tmp = primarySource;
        primarySource = secondarySource;
        secondarySource = tmp;

        yield break;
    }


    IEnumerator FadeSourceCoroutine(AudioSource sourceToFade, float startVolume, float endVolume, float duration)
    {
        float startTime = Time.time;

        while (true)
        {
            float elapsed = Time.time - startTime;

            sourceToFade.volume = Mathf.Clamp01(Mathf.Lerp(startVolume, endVolume, elapsed / duration));

            if (sourceToFade.volume == endVolume)
                break;

            yield return null;
        }
    }


    void Reset()
    {
        Update();
    }


    void Awake()
    {
        Update();
    }

}
