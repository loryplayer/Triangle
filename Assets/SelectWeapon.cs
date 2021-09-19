using System;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public  GameObject player;
    public  String[] Description={"Rifle","Shotgun","Sniper","Flamethrower"} ;
    public  GameObject[] armi;
    public  bool cambio1,cambio2;
    public static bool[] aggiorna=new bool[2];
    public int Cont;
    private Settaggio _settaggio;
    [FormerlySerializedAs("Image")] public RawImage image;

    public void Reset()
    {
        for (int i = 0; i < Description.Length; i++)
        {
            armi[i].SetActive(false);
        }

        image.color=new Color(0.59f, 0.24f, 0.24f);
        cambio1 = false;
        cambio2 = false;
    }

    void Update()
    {
        if (cambio1||cambio2)
        {
            AggiornaWeapon();

        }
        _settaggio = player.GetComponent<Settaggio>();
        if (Cont == 1)
        {
            try
            {
                for (int e=0; e<Description.Length;e++)
                {
                    //player=GameObject.FindWithTag("Player"); 
                    if (player.GetComponent<Settaggio>().armaupdate[0].GetDescription() == Description[e])
                    {
                        armi[e].SetActive(true);
                        aggiorna[0] = false;
                    }
                    else
                    {
                        armi[e].SetActive(false);
                    }
                }
            }
            catch (NullReferenceException)
            {}
        }
        if (Cont == 2&&_settaggio.cambioprimaarma)
        {
            
            for (int e=0; e<Description.Length;e++)
            {
                player=GameObject.FindWithTag("Player");
                if (player.GetComponent<Settaggio>().armaupdate[1].GetDescription() == Description[e])
                {
               //     Debug.Log("arma " + player.GetComponent<Settaggio>().armaupdate[1].GetDescription());
                    armi[e].SetActive(true);
                    aggiorna[1] = false;
                }
                else
                {
                    armi[e].SetActive(false);
                }
            }
        }
    }
    public void AggiornaWeapon()
    {
        if (_settaggio.Rotella==1&&Cont==1)
        {
              image.color=new Color(255,0,0);
        }else
        if(_settaggio.Rotella==0&&Cont==2)
        { 
            image.color=new Color(255,0,0);
            
            cambio2 = false;
        }else
        {
            image.color=new Color(0.59f, 0.24f, 0.24f);
        }
    }
}
