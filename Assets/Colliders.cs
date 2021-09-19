
using System;
using Proiettile;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    public CapsuleCollider[] colliders;
    public GameObject[] armi;
    public bool stop;
    public float cowndown;
    public void Abilita(bool abilita)
    {
        if (abilita)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
//                print("Mandi");
                colliders[i].enabled = true;
                
            }
        }
        else
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (cowndown > 0)
        {
            cowndown -= Time.deltaTime;
        }
        if (other.gameObject.CompareTag("Player")&&Input.GetKeyDown(KeyCode.E)&&!stop&&cowndown<=0)
        {
            var player=other.gameObject;
            var settaggio = player.gameObject.GetComponent<Settaggio>();
            stop = true;
            if (settaggio.cambioprimaarma)
            {
                for (int i = 0; i < armi.Length; i++)
                {
                    if (armi[i].GetComponent<DamageData>().desc == player.GetComponent<Settaggio>().Description)
                    { 
                        print(armi[i].name+"  "+player.GetComponent<Settaggio>().Description);

                        var position = other.transform.position;
                        GameObject arma;
                        arma = Instantiate(armi[i], new Vector3(position.x + 1, position.y, position.z),
                                player.transform.rotation);
                        if (arma != null)
                        {
                            arma.GetComponent<Weapon_Data>().Carica();
                            arma.transform.SetParent(GameObject.FindGameObjectWithTag("Contenitore").transform);
                            arma.GetComponent<Colliders>().Abilita(true);
                            arma.GetComponent<Rigidbody>().useGravity = true;
                        }
                        break;
                    }
                } var cont = GetComponent<Weapon_Data>();
       //         print("Tipologia: "+player.GetComponent<Settaggio>().Tipologia);
             settaggio.Narma[settaggio.Tipologia]=cont.arma;
            print(cont.Slowness + " oioioio" + settaggio.Slowness);
            }
           else
           {
               var cont = GetComponent<Weapon_Data>();
             //  print(cont.Slowness+" oioioio");
             settaggio.Narma[1]=cont.arma;
               BoxOpener.first = false;
               settaggio.cambioprimaarma = true;
               settaggio.firstarma = false;
               print(settaggio.Narma[1].GetDescription());
           }
           Destroy(gameObject);
        }
        else
        {
          //  stop = false;
        }
    }
}