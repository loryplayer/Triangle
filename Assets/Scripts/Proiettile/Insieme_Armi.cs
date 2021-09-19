using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Proiettile
{
    public class Insieme_Armi : MonoBehaviour
    {
        public static readonly Armi Default = new Armi(0.2f, 1, 2f, 300f, 15,8,0, "Default");
        public readonly Armi Rifle = new Armi(2.5f, 1, 3f, 315f,30,8,0, "Rifle");
        public readonly Armi Rifle1 = new Armi(2.5f, 2, 3.5f, 305f,20,6,0, "Rifle");
        public readonly Armi Rifle2 = new Armi(2f, 3, 4f, 295f,15,12,0, "Rifle");
        public readonly Armi Shotgun = new Armi(0.5f, 10, 10f, 340f, 70,10,0, "Shotgun");
        public readonly Armi Sniper = new Armi(0.6f, 1, 0.0f,  560f, 250, 11,1,"Sniper");
        public readonly Armi Flamethrower = new Armi(0, 0, 0.0f,  150f, 50, 0.5,1,"Flamethrower");
        public static List<Armi> Guns,Rguns;
        public static int volte=0;
        public static string[] desc=new string[3];

        private void Start()
        {
            Guns = new List<Armi>();
            //Guns.Add(Rifle);
            //Guns.Add(Rifle1);
            //Guns.Add(Rifle2);
            Guns.Add(Shotgun);
            Guns.Add(Shotgun);
            Guns.Add(Shotgun);
            //Guns.Add(Sniper);
            //Guns.Add(Sniper);
            //Guns.Add(Sniper);
            //Guns.Add(Flamethrower);
            //Guns.Add(Flamethrower);
            //Guns.Add(Flamethrower);
            Rguns=new List<Armi>();
            Rguns.Clear();
        }


        public static void Aggiungi(Armi weapon)
        {
            Rguns.Add(weapon);
        }

        public static Armi GetRandomGun()
        {
            var arma = Guns[Random.Range(0, 3)];
           
            return arma;
        }

        public static Armi GetRandomRgun()
        {
            return Rguns[Random.Range(0, Rguns.Count - 1)];
        }

        public static Armi GetRgun(int n)
        {
            return Rguns[n-1];
        }

        public static int GetInt(Armi ar)
        {
            int e=0;
            for (int j = 0; j < Rguns.Count; j++)
            {
                if (Rguns[j].GetDescription() == ar.GetDescription()&&Rguns[j].Getslowness() == ar.Getslowness()&&Rguns[j].GetBullets() == ar.GetBullets()&&Rguns[j].GetBullets() == ar.GetBullets()&&Rguns[j].GetDamage() == ar.GetDamage()&&Rguns[j].GetHeavy() == ar.GetHeavy()&&Rguns[j].GetOvercome() == ar.GetOvercome()&&Rguns[j].GetSpeed() == ar.GetSpeed()&&Rguns[j].GetSpread() == ar.GetSpread())
                {
                    e = j;
                    break;
                }
            }

            return e;
        }

    }
}

