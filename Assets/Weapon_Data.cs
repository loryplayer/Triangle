using System;
using Proiettile;
using UnityEngine;

public class Weapon_Data : MonoBehaviour
{
    public float Slowness, Bullets, Spread, Speed, Damage, Heavy,Overcome;
    public String Description;
    public Armi arma;
    void Start()
    {
        Carica();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Carica()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Slowness = player.GetComponent<Settaggio>().Getslowness();
            Bullets = player.GetComponent<Settaggio>().GetBullets();
            Spread = player.GetComponent<Settaggio>().GetSpread();
            Speed = player.GetComponent<Settaggio>().GetSpeed();
            Damage = player.GetComponent<Settaggio>().GetDamage();
            Heavy = (float) player.GetComponent<Settaggio>().GetHeavy();
            Overcome = player.GetComponent<Settaggio>().GetOvercome();
            Description = player.GetComponent<Settaggio>().GetDescription();
            arma = new Armi(Slowness, Bullets, Spread, Speed, Damage, Heavy, (int) Overcome, Description);
        }
    }
}
