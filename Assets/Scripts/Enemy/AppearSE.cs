using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearSE : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip appearSE;
    void Start()

    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(appearSE);
    }

    
}
