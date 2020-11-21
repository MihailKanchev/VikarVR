using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other){
        if(!audio.isPlaying)
            audio.Play();
        else
            audio.Pause();
    }
}
