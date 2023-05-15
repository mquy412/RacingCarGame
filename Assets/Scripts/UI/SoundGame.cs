using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGame : MonoBehaviour
{
    public AudioSource click;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        click = GetComponent<AudioSource>();
    }
    public void clickButton()
    {
        if (click.isPlaying) return;
        click.Play();
    }    
}
