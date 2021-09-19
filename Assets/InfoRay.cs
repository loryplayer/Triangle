using System;
using System.Data;
using UnityEngine;
using UnityEngine.Serialization;

public class InfoRay : MonoBehaviour
{
    public Camera cam;
    public GameObject infolab,o;
    public static GameObject lab;
    public Armi arma;
    public Vector3 position;
    public float distanza;
    public static bool distruggi;
    public Animator animator;
    public static bool showlab,hidelab;
    public float[] countdown;

    void Update()
    {
        if (!PauseMenu.pausa&&!distruggi)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                print("I premuta");
                RaycastHit hit;
                Ray lastRay = cam.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(lastRay.origin, lastRay.direction * 180, Color.green);
                if (Physics.Raycast(lastRay, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Cassa")||hit.collider.gameObject.CompareTag("Arma"))
                    {
                        var gobjpos = GameObject.Find("InfoPos");
                        o = hit.collider.gameObject;
                        position = gobjpos.transform.position;
                        gobjpos.transform.position = position;
                        if (lab == null)
                        {
                            lab = Instantiate(infolab,
                                position,
                                infolab.transform.rotation);
                            lab.transform.SetParent(gobjpos.transform);
                        }

                        if (hit.collider.gameObject.CompareTag("Cassa"))
                        {
                            var cassa = o.GetComponent<DamageData>().gameObject;
                            arma = cassa.GetComponent<RandomGun>().weapon;
                            print(o.name + "  " + cassa.name + "  " + arma.GetDescription());
                        }
                        else
                        {
                            arma = o.GetComponent<Weapon_Data>().arma;
                        }
                        lab.GetComponent<DamageData>().SetArma(arma);
                        lab.GetComponent<DamageData>().desc = arma.GetDescription();
                    }
                }
            }else if (Input.GetKeyDown(KeyCode.Mouse1)&&o!=null)
            {
                distruggi = true;
                print(o.gameObject);
            }
        }
        if (o != null&&lab!=null&&!hidelab)
        {
            distanza = Vector3.Distance(gameObject.transform.position, o.transform.position);
            if (distanza >= 100)
            {
                distruggi = true;
            }
        }
        else if(hidelab&&lab!=null)
        { 
            lab.SetActive(false);
        }
        if (lab != null&&!distruggi)
        {
                lab.GetComponent<Animator>().SetBool("Inizio",false);
                lab.GetComponent<Animator>().SetBool("Inattivo",true);
        }
        
        if (distruggi&&lab!=null)
        {
            lab.GetComponent<Animator>().SetBool("Inattivo",false);
            lab.GetComponent<Animator>().SetBool("Fine",true);
            if (lab.transform.localScale.x < 0.3)
            {
                Destroy(lab);
                distruggi = false;
            }
        }

        if (showlab&&lab!=null)
        {
            countdown[0] -= Time.deltaTime;
            if (countdown[0] <= 0)
            {
                lab.SetActive(true);
                showlab = false;
            }
        }
        if (!showlab)
        {
            countdown[0] = countdown[1];
        }
    }
}
