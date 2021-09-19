using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Proiettile;
using UnityEngine;
using Random = System.Random;

public class BoxOpener : MonoBehaviour
{
    public RuntimeAnimatorController act,act1;
    public GameObject cassa,player;
    public bool destroy,collision,stop,chiudi;
    public static bool first=true;
    private static bool spawn;
    public float speed=10f;
    private Timer time;
    public bool open;
    public GameObject[] armi;
    public Settaggio settaggio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collision = true;
            GameObject o;
            settaggio= (o = other.gameObject).GetComponent<Settaggio>();
            player = o;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collision = false;
            settaggio = null;
            player = null;
        }
    }
    void Update()
    {
        if (gameObject.GetComponent<DamageData>().gameObject.GetComponent<HitBox>().Vita > 0)
        {
            if (collision)
            {
                spawn = true;
                stop = false;
                cassa.GetComponent<Animator>().runtimeAnimatorController = act;
                if (Input.GetKeyDown("e"))
                {
                    if (settaggio.cambioprimaarma)
                    {
                        for (int i = 0; i < armi.Length; i++)
                        {

                            if (armi[i].name == settaggio.Description)
                            {
                                var position = player.transform.position;
                                var arma = Instantiate(armi[i], new Vector3(position.x + 1, position.y, position.z),
                                    player.transform.rotation);
                                arma.transform.SetParent(GameObject.FindGameObjectWithTag("Contenitore").transform);
                                arma.GetComponent<Colliders>().Abilita(true);
                                arma.GetComponent<Rigidbody>().useGravity = true;
                            }
                        }
                    }

                    CursorManager.caricamousecountdown = true;
                    var labinfo = GameObject.Find("InfoLab(Clone)");
                    if (labinfo != null)
                        InfoRay.distruggi = true;
                    open = true;
                    //Debug.Log(Insieme_armidesc.GetRgun(cassa.GetComponent<RandomGun>().narmaa+1).GetDescription());
                    destroy = true;
                    first = false;
                    SelectWeapon.aggiorna[0] = true;
                    SelectWeapon.aggiorna[1] = true;
                }
            }
            else if (cassa.GetComponent<Animator>().runtimeAnimatorController == act && !stop)
            {
                stop = true;
                time = new Timer(2410);
                time.Elapsed += Cassaclose;
                time.Enabled = true;
                time.AutoReset = false;
            }

            if (chiudi)
            {
                chiudi = false;
                cassa.GetComponent<Animator>().runtimeAnimatorController = act1;
            }

            if (destroy)
            {
                Vector3 direction = new Vector3(0, -1, 0);
                cassa.transform.Translate(Time.deltaTime * speed * direction);
                if (cassa.transform.position.y < -10)
                {
                    destroy = false;
                }
            }
        }
    }

    private void Cassaclose(object sender, ElapsedEventArgs e)
    {

        chiudi = true;
    }
}
