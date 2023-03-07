//Plays sound clips
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 
    public AudioClip shootClip; 
    public AudioClip sheepHitClip; 
    public AudioClip sheepDroppedClip;
    private Vector3 cameraPosition;

    //Awake is called before start
    void Awake()
    {
        Instance = this; 
        cameraPosition = Camera.main.transform.position; 
    }

    //Plays selected sound
    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    //Plays selected shooting sound
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    //Plays selected hit sound
    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    //Plays selected dropping sound
    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}
