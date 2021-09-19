using System;
using System.Collections;
using System.Collections.Generic;
using Blocco;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Remove : MonoBehaviour
{
    public GameObject Particella,ImpSound,Proiettile,muzzleprefab,contenitore,proiettileframmentato;
    private GameObject oggcoll;
    private bool stop;
    public void Start()
    {
        if (muzzleprefab != null)
        {
            contenitore=GameObject.FindGameObjectWithTag("Generator");
            var muzzle = Instantiate(muzzleprefab, transform.position, Quaternion.identity);
            muzzle.transform.forward = gameObject.transform.forward;
            muzzle.transform.SetParent(contenitore.GetComponent<SpawnBlock>().Contenitore.transform);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        oggcoll = collision.gameObject;
        if ((collision.gameObject.layer!=9&&gameObject.layer==9)&&!stop)
        {

            stop = true;
            var position = gameObject.transform.position;
            var transform1 = transform;
            var suono=Instantiate(ImpSound, transform1.position, transform1.rotation);
            suono.transform.SetParent(contenitore.GetComponent<SpawnBlock>().Contenitore.transform);
            var impattoPart=Instantiate(Particella, new Vector3(position.x, position.y, position.z), collision.transform.rotation);
            impattoPart.transform.SetParent(contenitore.GetComponent<SpawnBlock>().Contenitore.transform);
            NascondiProiettile();
        }
        else if((collision.gameObject.layer != 10 && gameObject.layer == 10)&&!stop)
        {            
            stop = true;
            var position = gameObject.transform.position;
            var transform1 = transform;
            var suono=Instantiate(ImpSound, transform1.position, transform1.rotation);
            suono.transform.SetParent(contenitore.GetComponent<SpawnBlock>().Contenitore.transform);
            var impattoPart=Instantiate(Particella, new Vector3(position.x, position.y, position.z), collision.transform.rotation);
            impattoPart.transform.SetParent(contenitore.GetComponent<SpawnBlock>().Contenitore.transform);
            NascondiProiettile();
            
        }
        
    }

    public void NascondiProiettile()
    {
        var transform1 = transform;
        var frammento = Instantiate(proiettileframmentato, transform1.position, transform1.rotation);
        GetComponent<ColorRay>().Colora(frammento,oggcoll);
        frammento.transform.SetParent(contenitore.GetComponent<SpawnBlock>().Contenitore.transform);
        gameObject.SetActive(false);
       // Destroy(gameObject,2);
    }
}