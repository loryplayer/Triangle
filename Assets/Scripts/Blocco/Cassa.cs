
using System;
using System.Collections.Generic;
using System.Timers;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Cassa : MonoBehaviour
{
    
    [FormerlySerializedAs("Armi")] public GameObject[] armi = new GameObject[4];
    private float _newSlowness, _newBullets, _newSpread, _newSpeed, _newDamage, _newHeavy;
    public Armi _armirandom;
    public int rarita;
    public string desc;
    public bool stop;
    private Timer _aTimer;
    public GameObject box,arma;
    public static int e;

    private void Start()
    {
        gameObject.name = e.ToString();
        stop = true;
        e++;
    }


    void Update()
    {
        //print(stop);
        if (box.GetComponent<BoxOpener>().open)
        {
            var player = box.GetComponent<BoxOpener>().player;
            var settaggio = player.GetComponent<Settaggio>();
            Armi numeroarma = gameObject.GetComponent<RandomGun>().weapon;
            if(settaggio.Rotella == 2)
            {
                
                print("armainserita "+stop);
                stop = true;
                settaggio.Narma[1] =numeroarma;
                // Debug.Log(gameObject.GetComponent<RandomGun>().narmaa);
                settaggio.cambioprimaarma = true;
                settaggio.firstarma = false;
            }else
            if(settaggio.Rotella == 1&&settaggio.Narma[1].GetDescription()==" "&&settaggio.Narma[0].GetDescription()!=" ")
            {
                print("armainserita "+stop);
                stop = true;
                settaggio.Narma[1] =numeroarma;
                // Debug.Log(gameObject.GetComponent<RandomGun>().narmaa);
                settaggio.cambioprimaarma = true;
                settaggio.firstarma = false;
            }
            else if (settaggio.Rotella == 1)
            {
                stop = false;
                settaggio.Narma[0] = numeroarma;
            }
            
            box.GetComponent<BoxOpener>().open = false;
        }
    }
    
    public void Image(String weapon)
    {
        desc=weapon;
        for (int i = 0; i < armi.Length; i++)
        {
            
            if (armi[i].name ==weapon)
            {
                var o = gameObject;
                var position = o.transform.position;
                arma = Instantiate(armi[i],
                    new Vector3(position.x, (float) (position.y + 0.5),
                        position.z), Quaternion.Euler(new Vector3(90, 0, 90)));
                arma.transform.SetParent(gameObject.transform);
                break;
            }
        }
    }
    
}
        



        
    




                                              