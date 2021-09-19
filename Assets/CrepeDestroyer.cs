using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrepeDestroyer : MonoBehaviour
{
    public float durata = 0.5f;
    public bool collisione,distruzioneFrattureProiettile;
    

    public void Start()
    {
        if(!distruzioneFrattureProiettile)
            gameObject.tag = "Crepe";
    }

    public void OnCollisionEnter(Collision other)
    {
        if (!distruzioneFrattureProiettile)
        {
            if (!other.gameObject.CompareTag(gameObject.tag) && !other.gameObject.CompareTag("Player"))
            {
                collisione = true;
            }
        }
    }

    void Update()
    {
        if (!distruzioneFrattureProiettile)
        {
            Rigidbody rg = gameObject.GetComponent<Rigidbody>();
            if (rg.velocity == Vector3.zero && collisione)
            {
                durata -= Time.deltaTime;
                if (durata <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            int j = 0;
            var fratturaproiettile = gameObject.GetComponent<DamageData>().info;
            for (int i = 0; i < fratturaproiettile.Length; i++)
            {
                if (fratturaproiettile[i] != null)
                {
                    j++;
                }

                if (j == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
