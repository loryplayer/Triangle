using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimozioneAudio : MonoBehaviour
{
    private GameObject online;
    void Start()
    {
        online=GameObject.Find("Online(Clone)");
        online.GetComponent<AudioListener>().enabled = false;
    }
}
