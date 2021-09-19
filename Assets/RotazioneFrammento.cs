using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotazioneFrammento : MonoBehaviour
{
    public bool vaisu;
    public float speed = 1;
    public float rotationspeed = 1;
    public float[] countdown;

    void Update()
    {
        if (vaisu)
        {
            var transform1 = transform;
            transform1.position = transform1.position + new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            var transform1 = transform;
            transform1.position = transform1.position - new Vector3(0, speed * Time.deltaTime, 0);
        }
        transform.Rotate(Vector3.up, rotationspeed,Space.World);
        countdown[0] -= Time.deltaTime;
        if (countdown[0] <= 0)
        {
            countdown[0] = countdown[1];
            vaisu = !vaisu;
        }
    }
}
