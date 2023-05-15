using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSFX : MonoBehaviour
{
    public AudioSource soundtrack;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        soundtrack = GetComponent<AudioSource>();
    }
    public void SFXPlay()
    {
        if (soundtrack.isPlaying) return;
        soundtrack.Play();
    }
    public void SFXStop()
    {
        if (!soundtrack.isPlaying) return;
        soundtrack.Stop();
    }
}
