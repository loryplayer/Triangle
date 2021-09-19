using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Blocco;
using Proiettile;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefub,player;
    private Quaternion _firepointLocalRotation;
    public bool Enemy,shoot;
    public float firerate,update;
    public float  distance;
    public GameObject GameObject,Contenitore;
    public GameObject Fire;
    public static bool impostato;
    private Settaggio _settaggio;



    void Update()
    {_settaggio=gameObject.GetComponent<Settaggio>();
        if (!Enemy)
        {
            if (update <= firerate)
            {
                update += Time.deltaTime;
            }
            
            if (_settaggio.Rotella == 1&&!impostato)
            {
                impostato = true; 
                firerate = _settaggio.coundown[1,0];
                update=_settaggio.coundown[1,1];
            }else
            if (_settaggio.Rotella == 0&&!impostato)
            {
                impostato = true;
                firerate = _settaggio.coundown[0,0];
                update=_settaggio.coundown[0,1];
            }

            if (Input.GetButton("Fire1") && !PauseMenu.pausa)
            {
                if (!BoxOpener.first)
                {
                    if (shoot && !_settaggio.fiameggiante)
                    {
                        if (update>firerate) 
                        {
                            firerate = update + 1 / _settaggio.Slowness;
                            for (int i = 1; i <= _settaggio.Bullets; i++)
                            {
                                Controllo();
                            }
                        }
                    }

                }
            }
        }
        else
        {
            GameObject o;
            player = (o = gameObject).GetComponent<EnemyController>().playervicino;
            distance = Vector3.Distance(player.transform.position, o.transform.position);
            if (distance <= 50)
            {
                if (Time.time>=firerate)
                {
                    firerate = Time.time + 1 / _settaggio.Slowness;
                        for (int i = 1; i <= _settaggio.Bullets; i++)
                        {
                            Controllo();
                        }
                }
            }
        }
        if (_settaggio.fiameggiante)
        {
            
            if (gameObject.layer == 8)
            {
                Fire.GetComponent<DamageData>().Danno = _settaggio.GetDamage();
                
            }
            else
            {
                Fire.GetComponent<DamageData>().Danno = _settaggio.Damage;
                
            }
        }
    }
    
    void Controllo()
    {
        if (!Enemy)
        {
            if (!Particel.dash)
            {
                Shoot();
            }
            /*
            GameObject bullet1=Instantiate(bulletPrefub, new Vector3( (position1.x),2,position1.z),  rotation);
            Rigidbody rb1=bullet1.GetComponent<Rigidbody>();
            rb1.AddForce(new Vector3((float) (rotation.x+0.5),0, (float) (rotation.x+0.5))*bulletForce,ForceMode.Impulse);
            GameObject bullet2=Instantiate(bulletPrefub, new Vector3((position2.x),2,position2.z), rotation);
            Rigidbody rb2=bullet2.GetComponent<Rigidbody>();
            rb2.AddForce(firepoint2.up*bulletForce,ForceMode.Impulse);
            */
        }
        else
        {
            Shoot();
        }
    }

    void Shoot()
    {

        var position = firepoint.position;
        var localRotation = firepoint.localRotation;
        var forward = firepoint.forward;
        float rndrotation = Random.Range(localRotation.x - (90 + _settaggio.GetSpread()),
            localRotation.x - (90 - _settaggio.GetSpread()));
        Transform transform1;
        (transform1 = firepoint.transform).localRotation = Quaternion.Euler(new Vector3(rndrotation, 90, -90));
        Vector3 rotationfirepoint = transform1.rotation.eulerAngles;
        GameObject bullet;
        if (gameObject.layer == 8)
        {
            bullet = Instantiate(bulletPrefub, new Vector3(position.x, 2, position.z), Quaternion.LookRotation(forward));
            //bullet.transform.rotation = Quaternion.Euler(new Vector3(90,rotationfirepoint.y,0));
            bullet.layer = 9;
            bullet.GetComponent<DamageData>().rotation = new Vector3(rotationfirepoint.y, 90, -90);
            bullet.GetComponent<DamageData>().spread = rndrotation;
            bullet.GetComponent<DamageData>().Danno = _settaggio.GetDamage();
            bullet.GetComponent<DamageData>().gameObject = gameObject;
        }
        else
        {
            var rotation2 = gameObject.GetComponent<Rotation>().rotation1;
            //Debug.Log(rndrotation + "Rotazioniiii");
            bullet = Instantiate(bulletPrefub, new Vector3(position.x, 2, position.z),Quaternion.LookRotation(forward));
            bullet.layer = 10;
            bullet.GetComponent<DamageData>().Danno = _settaggio.Damage;
            bullet.GetComponent<DamageData>().gameObject = gameObject;
        }

        Contenitore = GameObject.FindWithTag("Contenitore");
        bullet.transform.SetParent(Contenitore.transform);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.mass = (float) _settaggio.Heavy;
        rb.AddForce(forward * _settaggio.Speed, ForceMode.Impulse);
        
    }
    
}
