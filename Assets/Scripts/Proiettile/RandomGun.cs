using System;
using System.Collections;
using System.Collections.Generic;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class RandomGun : MonoBehaviour
{
    public int Rarità;
    public int narmaa=0,armaaaaaA;
    public float _newSlowness, _newBullets, _newSpread, _newSpeed, _newDamage, _newHeavy;
    bool _stop=false;
    [FormerlySerializedAs("_armirandom")] public Armi armirandom;
    [SerializeField]
    public Armi weapon;



    public void Carica()
    {

        float slown = 0;
        _newSlowness = Rarità / 20 * 10;
        _newBullets = 0;
        if (Rarità > 3)
        {
            _newBullets += Rarità - 2;
        }
        armirandom = Insieme_Armi.GetRandomGun();
        _newSpread =4 - Rarità;
        _newSpeed = Rarità * 3;
        _newDamage = Rarità * 25;
        _newHeavy = Rarità / 10;
        if (armirandom.GetDescription() == "Flamethrower")
        {
            _newBullets = -armirandom.GetBullets();
            _newSlowness = -armirandom.Getslowness();
            _newSpread = -armirandom.GetSpread();
            _newHeavy = (float) (armirandom.GetHeavy() / 2);
        }
        weapon =new Armi (
            armirandom.Getslowness() + _newSlowness,
            armirandom.GetBullets() + _newBullets,
        armirandom.GetSpread() + _newSpread,
        armirandom.GetSpeed() + (_newSpeed * Rarità),
        (armirandom.GetDamage() + (_newDamage * Rarità)),
        armirandom.GetHeavy() - (_newHeavy * 2), armirandom.GetOvercome(),
        armirandom.GetDescription());
        Insieme_Armi.Aggiungi(weapon);
        narmaa= Insieme_Armi.GetInt(weapon);
        //print("Weapon desc "+weapon.GetDescription()+" Random desc "+armirandom.GetDescription());
        gameObject.GetComponent<Cassa>().Image(armirandom.GetDescription());
    }

    private void Update()
    {
        
    }
}
