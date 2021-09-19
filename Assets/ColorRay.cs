using System;
using System.Collections;
using System.Collections.Generic;
using Blocco;
using UnityEngine;

public class ColorRay : MonoBehaviour
{
    private RaycastHit _oggcoll;
    public Material mat,colorebase;
    public float distanza,raggio;

    void Update()
    {
        var gameObject1 = gameObject;
        Ray ray=new Ray(gameObject1.transform.position, gameObject1.transform.forward);
        if (Physics.SphereCast(ray,raggio, out _oggcoll))
        {
            var o = gameObject;
//            print(_oggcoll.transform.name);
            if (_oggcoll.collider.gameObject != null&&_oggcoll.collider.gameObject.GetComponent<Renderer>()!=null && _oggcoll.collider.gameObject.layer != gameObject.layer)
            {
                distanza = _oggcoll.distance;
                if (_oggcoll.collider.gameObject.GetComponent<HitBox>() != null)
                {
                    mat = _oggcoll.collider.gameObject.GetComponent<HitBox>().reset;
                }
                else
                {
                    mat = _oggcoll.collider.gameObject.GetComponent<Renderer>().material;
                }
            }else if (_oggcoll.collider.gameObject.layer == 9 || _oggcoll.collider.gameObject.layer == 10)
            {
                mat = colorebase;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.blue;
        var o = gameObject;
        var position = GameObject.FindGameObjectWithTag("Player").transform.position;
        var forward = o.transform.forward;
        Debug.DrawLine(position,position+forward*distanza);
        Gizmos.DrawWireSphere(position+forward*distanza,raggio);
    }

    public void Colora(GameObject frammento,GameObject oggettocolliso)
    {

        var frammenti = frammento.GetComponent<DamageData>().info;
        foreach (var framm in frammenti)
        {
            try
            {
                if (distanza > 10)
                {
                    if (_oggcoll.collider.gameObject.GetComponent<HitBox>().reset != null)
                    {
                        framm.GetComponent<Renderer>().material = mat;
                        framm.GetComponent<Renderer>().materials = new[]
                            {mat, mat};
                    }
                }
                else
                {
                    framm.GetComponent<Renderer>().material = oggettocolliso.GetComponent<Renderer>().material;
                    framm.GetComponent<Renderer>().materials = new[]
                    {
                        oggettocolliso.GetComponent<Renderer>().material,
                        oggettocolliso.GetComponent<Renderer>().material
                    };
                }
            }
            catch (NullReferenceException)
            {
                framm.GetComponent<Renderer>().materials = new[]
                    {mat, mat};
            }
            catch (MissingComponentException)
            {
                if (oggettocolliso.GetComponent<SpriteRenderer>() != null)
                {
                    framm.GetComponent<Renderer>().material.color = oggettocolliso.GetComponent<SpriteRenderer>().color;
                    framm.GetComponent<Renderer>().materials = new[]
                        {framm.GetComponent<Renderer>().material, framm.GetComponent<Renderer>().material};
                }
            }
        }
    }
}
