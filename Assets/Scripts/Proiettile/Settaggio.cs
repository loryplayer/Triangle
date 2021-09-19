using System;
using System.Diagnostics;
using Proiettile;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Proiettile
{
    public class Settaggio : MonoBehaviour
    {
        public Armi Armi;
        public int Tipologia;
       public bool cambioprimaarma,firstarma;
       public bool fiameggiante;
       public float Slowness, Bullets, Spread, Speed, Damage, Heavy;
       public String Description;
       public Armi[] Narma = new Armi[2];
       public Armi[] armaupdate=new Armi[2];
       public int Rotella=1;
       public float[,] coundown=new float[2,2];
       public GameObject PrimoCont,SecondoCont;
       public bool Enemy,stop,salvato;
       private bool armapresa;

       public void Reset(bool fine)
       {
           cambioprimaarma = false;
           Rotella = 1;
           Armi = null;
           Narma = new Armi [2];
           armaupdate = new Armi [2];
           armapresa = false;
           fiameggiante = false;
           BoxOpener.first = true;
           firstarma = false;
           gameObject.GetComponent<Particel>().Reset();
           PrimoCont.GetComponent<SelectWeapon>().Reset();
           SecondoCont.GetComponent<SelectWeapon>().Reset();
           Armi=new Armi(0,0,0,0,0,0,0," ");
           for (int i = 0; i < Narma.Length; i++)
           {
               Narma[i]=new Armi(0,0,0,0,0,0,0," ");
           }
           if (fine)
           {
               gameObject.GetComponent<Raccoltaframmento>().frammenti = 0;
           }
           
           var Infoobj = GameObject.Find("InfoLab(Clone)");
           Destroy(Infoobj);
           
       }

       public void Start()
       {
           Armi=new Armi(0,0,0,0,0,0,0," ");
           for (int i = 0; i < Narma.Length; i++)
           {
               Narma[i]=new Armi(0,0,0,0,0,0,0," ");
           }
       }

       void Update()
       {
           if (!Enemy)
           {
               armaupdate = Narma;
               if (!BoxOpener.first)
               {

                   if (cambioprimaarma)
                   {
                       if (Input.GetAxis("Mouse ScrollWheel") > 0 &&
                           Input.GetAxis("Mouse ScrollWheel") < Insieme_Armi.Rguns.Count && Rotella == 0)
                       {
                           Rotella=1;
                           if (stop)
                           {
        //                       print("Rotella1");
                               stop=!stop;
                               Shooting.impostato = false;
                               
                               coundown[0,0]= gameObject.GetComponent<Shooting>().firerate;
                               coundown[0,1]= gameObject.GetComponent<Shooting>().update;
                           }
                       }
                       else if (Input.GetAxis("Mouse ScrollWheel") < 0 && Rotella == 1)
                       {
                           Rotella=0;
                           if (!stop)
                           {
//                               print("Rotella0");
                               stop=!stop;
                               Shooting.impostato = false;
                               coundown[1,0]= gameObject.GetComponent<Shooting>().firerate;
                               coundown[1,1]= gameObject.GetComponent<Shooting>().update;
                           }
                       }
                   }
                   if (Rotella == 0)
                   {
                       Armi = Narma[1];
                       Tipologia = 1;
                       SecondoCont.GetComponent<SelectWeapon>().cambio2 = true;
                       PrimoCont.GetComponent<SelectWeapon>().cambio1 = true;

                   }
                   else if (Rotella == 1)
                   {
                       
                       Armi = Narma[0];
                       PrimoCont.GetComponent<SelectWeapon>().cambio1 = true;
                       SecondoCont.GetComponent<SelectWeapon>().cambio1 = true;
                       Tipologia = 0;
                       if (!cambioprimaarma)
                       {
                           firstarma = true;
                       }
                   }

                   try
                   {
                       Slowness = Armi.Getslowness();
                       Bullets = Armi.GetBullets();
                       Spread = Armi.GetSpread();
                       Speed = Armi.GetSpeed();
                       Damage = Armi.GetDamage();
                       Heavy = (float) Armi.GetHeavy();
                       Description = Armi.GetDescription();
                       if (Armi.GetDescription() == "Flamethrower")
                       {
                           fiameggiante = true;
                       }
                       else
                       {
                           fiameggiante = false;
                       }
                   }
                   catch (NullReferenceException)
                   { }


               }
           }else if(!armapresa)
           {
               Enemies randomEnemy;
               bool armaassociata = false;
               int count = 0;
               do
               {
                   count++;
                   randomEnemy= Insieme_Nemici.GetRandomRenemy();
                   Armi = Insieme_Armi.GetRandomRgun();
                   if (randomEnemy.GetDescription() == "Tank" && Armi.GetDescription() == "Shotgun")
                   {
                       armaassociata = true;
                   }else if (randomEnemy.GetDescription() == "Assault" && Armi.GetDescription() == "Rifle")
                   {
                       armaassociata = true;
                   }else if (randomEnemy.GetDescription() == "Sniper" && Armi.GetDescription() == "Sniper")
                   {
                       armaassociata = true;
                   }else if (randomEnemy.GetDescription() == "Flamethrower" && Armi.GetDescription() == "Flamethrower")
                   {
                       armaassociata = true;
                   }
                   
                   if (count >= Insieme_Nemici.Renemies.Count)
                   {
                       
                   }
               } while (!armaassociata);
               armapresa = true;
                CaricaNemico(randomEnemy);
           }


       }

       public void CaricaNemico( Enemies randomEnemy)
       {
           gameObject.GetComponent<Health>().health += randomEnemy.GetHealth();
           gameObject.GetComponent<Health>().vita += randomEnemy.GetHealth();
           gameObject.GetComponent<NavMeshAgent>().speed = randomEnemy.GetSpeed();
           Slowness = Getslowness();
           Bullets = GetBullets();
           Spread = GetSpread();
           Speed = GetSpeed();
           Damage = GetDamage() + randomEnemy.GetDamage();
           Heavy = (float) GetHeavy();
           Description = GetDescription()+"  "+randomEnemy.GetDescription();
           if (Armi.GetDescription() == "Flamethrower")
           {
               fiameggiante = true;
           }
           else
           {
               fiameggiante = false;
           }
       }
        public float Getslowness() {
            return Armi.Getslowness();
        }

        public float GetBullets() {
            return Armi.GetBullets();
        }

        public float GetSpread() {
            return Armi.GetSpread();
        }

        public float GetSpeed() {
            return Armi.GetSpeed();
        }

        public string GetDescription() {
            return Armi.GetDescription();
        }

        public float GetDamage() {
            return Armi.GetDamage();
        }
        public double GetHeavy() {
            return Armi.GetHeavy();
        }
        public int GetOvercome() {
            return Armi.GetOvercome();
        }
    }
}

                    /*Cambio arma con la rotella:
 

                    
                    */
