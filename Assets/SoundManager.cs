using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    public void SoundPlay(AudioSource origen,AudioClip clip)
    {
        origen.pitch = Random.Range(0.9f, 1.1f);
        origen.volume = Random.Range(0.5f, 0.7f);
        origen.PlayOneShot(clip);
    }
}
