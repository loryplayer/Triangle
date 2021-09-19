using System;
using System.Collections;
using System.Collections.Generic;
using Blocco;
using Proiettile;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    public bool collisione;
    public Material mat;
    public Material reset;
    public GameObject particella, ExplosionPrefab, cassa, contenitore, frattura;
    private ParticleSystem.MainModule _mainModule;
    public float Vita, Danno,distanza;
    public int Health;
    public float[] collisioneparticelle, timereset;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.name == "Proiettile(Clone)")
        {
            Danno = collision.gameObject.GetComponent<DamageData>().Danno;
            _mainModule = particella.GetComponent<ParticleSystem>().main;
            var player = collision.gameObject.GetComponent<DamageData>().gameObject;
            collisione = true;
            var position = collision.transform.position;
            if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
            {
                GameObject fire = Instantiate(particella,
                    new Vector3(position.x, (float) (position.y + 0.3), position.z), collision.transform.rotation);
                fire.transform.SetParent(gameObject.transform);
            }
            else
            {

                Instantiate(particella, new Vector3(position.x, position.y, position.z), collision.transform.rotation);
                _mainModule.maxParticles = 3;
            }

            if (player.GetComponent<Settaggio>().Armi.GetDescription() == "Shotgun")
            {
                distanza = Vector3.Distance(player.transform.position, gameObject.transform.position);
                var moltiplicatore = 1 / distanza * 15;
                Danno *= moltiplicatore;
            }
        }
        else if (collision.collider.gameObject.CompareTag("Player") && Particel.dash)
        {
            _mainModule = particella.GetComponent<ParticleSystem>().main;
            var o = gameObject;
            var position = o.transform.position;
            var part = Instantiate(particella, new Vector3(position.x, position.y, position.z), o.transform.rotation);
            part.transform.SetParent(contenitore.transform);
            _mainModule.maxParticles = 300;
            Distruggi();
        }
    }

    private void Start()
    {
        Vita = Health;
        contenitore = GameObject.FindGameObjectWithTag("Generator").GetComponent<SpawnBlock>().Contenitore;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.name == "Splinter")
        {
            Vita -= 500;
            if (!gameObject.CompareTag("Base") && gameObject.GetComponent<Rigidbody>() != null)
            {
                gameObject.GetComponent<Rigidbody>().velocity = other.transform.forward;
            }
        }
        else if (other.name == "Fiamma(Clone)")
        {
            timereset[0] = timereset[1];
            collisioneparticelle[0] -= Time.deltaTime;
            if (collisioneparticelle[0] <= 0)
            {
                collisione = true;
                Danno = other.GetComponent<DamageData>().Danno * 3 / 100;
            }
        }
    }

    void Update()
    {
        if (!collisione && timereset[0] > 0)
        {
            timereset[0] -= Time.deltaTime;
            if (timereset[0] <= 0)
            {
                collisioneparticelle[0] = collisioneparticelle[1];
            }
        }

        if (collisione && Vita > 0)
        {
            Vita -= Danno;
            if (gameObject.name == "Cassa(Clone)")
            {
                cassa.GetComponent<Renderer>().material = mat;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = mat;
            }

            collisione = false;
        }
        else if (Vita <= 0)
        {
            Distruggi();
        }
        else
        {

            if (gameObject.name == "Cassa(Clone)")
            {
                cassa.GetComponent<Renderer>().material = reset;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material = reset;
            }
        }
    }

    public void Distruggi()
    {
        if (CursorManager.targetobject == gameObject)
        {
            var cursormanager = GameObject.FindGameObjectWithTag("Cursormanager");
            cursormanager.GetComponent<CursorManager>().Distruggi(false);
        }

        if (gameObject.name == "Barile(Clone)" && !Particel.dash)
        {
            var transform1 = transform;
            GameObject exp = Instantiate(ExplosionPrefab, transform1.position, transform1.rotation);
            exp.transform.SetParent(contenitore.transform);
            exp.GetComponent<ExplosionBarile>().ExplosionEff();
        }

        var transform2 = transform;
        var position = transform2.position;
        var fract = Instantiate(frattura, new Vector3(position.x, position.y - 1.8f, position.z), transform2.rotation);
        fract.transform.SetParent(contenitore.transform);
        if (gameObject.CompareTag("Cassa"))
        { 
           //Transform transform1;
           // var arma = Instantiate(GetComponent<Cassa>().arma, (transform1 = transform).position, transform1.rotation);
           // arma.name = "Trovami";
           // print(arma.name);
            var armavecchia = GetComponent<Cassa>().arma;
            armavecchia.transform.SetParent(GameObject.FindGameObjectWithTag("Contenitore").transform);
            armavecchia.GetComponent<Colliders>().Abilita(true);
            armavecchia.GetComponent<Rigidbody>().useGravity = true;
            Material mat = gameObject.GetComponent<DamageData>().info[0].GetComponent<Colours>().Material;
            fract.GetComponent<DamageData>().info[0].GetComponent<Colours>().CaricaMaterial(mat);
            armavecchia.GetComponent<Weapon_Data>().arma = gameObject.GetComponent<RandomGun>().weapon;
        }
        Destroy(gameObject);
    }
}