using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class Armi : MonoBehaviour
{
    private float slowness;
    private float bullets;
    private float spread;
    private float speed;
    private float damage;
    private double heavy;
    private string description;
    private int overcome;
    
    public Armi(float slowness, float bullets, float spread, float speed, float damage, double heavy,int overcome, string desc) {
        this.slowness = slowness;
        this.bullets = bullets;
        this.spread = spread;
        this.speed = speed;
        this.damage = damage;
        this.heavy = heavy;
        this.overcome = overcome;
        this.description = desc;

    }
    public float Getslowness() {
        return slowness;
    }

    public float GetBullets() {
        return bullets;
    }

    public float GetSpread() {
        return spread;
    }

    public float GetSpeed() {
        return speed;
    }

    public string GetDescription() {
        return description;
    }
    public double GetHeavy() {
        return heavy;
    }
    public int GetOvercome() {
        return overcome;
    }

    public float GetDamage() {
        return damage;
    }
    
}
