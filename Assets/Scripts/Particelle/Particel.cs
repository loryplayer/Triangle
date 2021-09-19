using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;

public class Particel : MonoBehaviour
{
    [FormerlySerializedAs("Particella")] public GameObject Scia;
    [FormerlySerializedAs("Fiamma")] public GameObject fiamma;
    [FormerlySerializedAs("_mainModuleFire")] public ParticleSystem.MainModule mainModuleFire;
    public static bool dash;
    public static float[] coundown=new float[4];
    public AudioSource loop,partefin;
    public bool stop;


    private void Start()
    {
            Reset();
    }

    void Update()
    {
        if (gameObject.layer != 11)
        {
            mainModuleFire = fiamma.GetComponent<ParticleSystem>().main;

            if (coundown[2] < coundown[3])
            {
                coundown[2] += Time.deltaTime;
            }
            if (coundown[2] >= coundown[3])
            {
                coundown[0] = coundown[1];
            }
            if (Input.GetKey("w"))
            {
                if (!PauseMenu.pausa)
                {
                    if (Input.GetKey("space") && coundown[0] > 0)
                    {
                        if (!stop)
                        {
                            stop = true;
                            loop.Play();
                        }

                        coundown[0] -= Time.deltaTime;
                        coundown[2] = (coundown[0] * coundown[3]) / coundown[1];
                        dash = true;
                        var rb = gameObject.GetComponent<Rigidbody>();
                        rb.mass = 10;
                        var direction = new Vector3(0, 0, 0);
                        direction.y = Input.GetAxis("Vertical");
                        transform.Translate(Time.deltaTime * (Movement.speed) * direction);
                        Scia.SetActive(true);
                    }
                    else if (Input.GetKeyUp("space"))
                    {
                        loop.Stop();
                        partefin.Play();
                        stop = false;
                        Scia.SetActive(false);
                    }
                    else
                    {
                        Scia.SetActive(false);
                        loop.Stop();
                        dash = false;
                    }
                }
                else
                {
                    loop.Stop();
                    partefin.Play();
                    Scia.SetActive(false);
                }
            }
            else
            {

                dash = false;
                mainModuleFire.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
            }
        }

        if (gameObject.GetComponent<Settaggio>().fiameggiante)
        {
            if (gameObject.GetComponent<Shooting>().shoot && !dash)
            {
                if (gameObject.layer !=11)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        mainModuleFire.maxParticles = 500;
                        mainModuleFire.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
                        
                    }
                    else
                    {
                        mainModuleFire.maxParticles = 0;
                    }
                }
                else
                {
                    if (gameObject.GetComponent<Shooting>().distance <= 50)
                    { 
                        mainModuleFire.maxParticles = 500;
                        mainModuleFire.startRotation = gameObject.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
                    }
                    else
                    {
                        mainModuleFire.maxParticles = 0;
                    }
                }

            }
            else
            {
                mainModuleFire.maxParticles = 0;
            }
        }
        else
        {
            mainModuleFire.maxParticles = 0;
        }
    }



    public void Destroy()
    {
        fiamma.transform.parent = null;
        mainModuleFire.maxParticles = 0;
        fiamma.transform.localScale = new Vector3((float) 0.2,(float) 0.2,(float) 0.2);
        Destroy(gameObject);
    }

    public void Reset()
    {
        if (gameObject.layer == 11)
        {
            mainModuleFire = fiamma.GetComponent<ParticleSystem>().main;
            mainModuleFire.maxParticles = 0;
        }
        else
        {
            coundown[0] = 2;
            coundown[1] = 2;
            coundown[2] = 20;
            coundown[3] = 20;
        }
        var nfigli = gameObject.transform.childCount;
        for (int i = 0; i < nfigli; i++)
        {
            var figlio = gameObject.transform.GetChild(i);
            if (figlio.name == "Fiamma")
            {
                Destroy(figlio.gameObject);
            }
        }
    }
}
