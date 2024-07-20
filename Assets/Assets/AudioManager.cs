using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnum;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource sfxSource; // Audio source for sound effects
    public AudioSource musicSource; // Audio source for music
    public AudioSource walkingSource; // Audio source for walking sound

    public AudioClip walkingClip; // Audio clip for walking sound

    public AudioClip pickUpClip;
    public AudioClip mucicClip;

    void Start()
    {
        if (walkingSource != null && walkingClip != null)
        {
            walkingSource.clip = walkingClip;
            walkingSource.loop = true; // Set the walking sound to loop
        }
    }

    // Function to play a sound effect
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    // Function to play music
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource != null)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    // Function to play the walking sound while moving
    public void PlayWalkingSound(bool isMoving)
    {
        if (walkingSource != null)
        {
            if (isMoving && !walkingSource.isPlaying)
            {
                walkingSource.Play();
            }
            else if (!isMoving && walkingSource.isPlaying)
            {
                walkingSource.Stop();
            }
        }
    }
}
