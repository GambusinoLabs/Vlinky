using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip finalLoop;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayFinalLoopAfter());
        audioSource.volume *= AudioManager.instance.overallMusicVolume;
    }

    IEnumerator PlayFinalLoopAfter()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = finalLoop;
        audioSource.Play();
        audioSource.loop = true;
    }
}
