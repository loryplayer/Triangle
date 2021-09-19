using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SommaFrammenti : MonoBehaviour
{
    public int numeroframmenti;
    public int Somma()
    { 
        numeroframmenti = 0;
       GameObject[] players=GameObject.FindGameObjectsWithTag("Player");
       foreach (var player in players)
       {
           numeroframmenti+=player.GetComponent<Raccoltaframmento>().frammenti;
       }
       return numeroframmenti;
    }
}
