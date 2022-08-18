using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController>
{
    private void Awake()
    {
        base.Awake();
    }
    public enum SoundType
    {
        death = 0,
        fly = 1,
        scored = 3,
    }
    public AudioSource audioFx;
    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
        }
    }
    public void OnPlayAudio(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Sounds/{soundType.ToString()}");
        audioFx.clip = audio;
        audioFx.Play();
    }
}
