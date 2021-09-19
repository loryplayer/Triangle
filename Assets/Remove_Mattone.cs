using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;

public class Remove_Mattone : MonoBehaviour
{
    [FormerlySerializedAs("_aTimer")] public Timer aTimer;
    private bool collisione,collisionealtare;
    private float coundown=1;

    private void Update()
    {
        if (coundown > 0)
        {
            coundown -= Time.deltaTime;
        }
        else if (collisione)
        {
            collisione = false;
        }

        if (collisione||collisionealtare)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionStay(Collision collision)  
    {
        if (collision.gameObject.layer == 12||collision.gameObject.layer == 13||collision.gameObject.layer == 0||collision.gameObject.layer == 11||collision.gameObject.layer == 8)
        {
            collisione = true;
        }

        if (collision.collider.CompareTag("Altare"))
        {
            collisionealtare = true;
            print("collisioneeeeeee");
        }
    }
}
