using System.Collections;
using System.Collections.Generic;
using Blocco;
using UnityEngine;

public class ExplosionBarile : MonoBehaviour
{
    public AudioSource exp;
    public GameObject Explosion;
    public void ExplosionEff()
    {
//        print("Esplosione!!!");
        exp.Play();
        var o = gameObject;
        var position = o.transform.position;
        var explosion=Instantiate(Explosion, new Vector3(position.x, (float) (position.y+1), position.z), o.transform.rotation);
        var contenitore = GameObject.FindGameObjectWithTag("Generator").GetComponent<SpawnBlock>().Contenitore;
        explosion.transform.SetParent(contenitore.transform);
    }
}

