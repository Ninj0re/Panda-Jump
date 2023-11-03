using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private ButtonController bC;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if(bC.GetSoundActiveness())
            source.PlayOneShot(source.clip);
    }
}
