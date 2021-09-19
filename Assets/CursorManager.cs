using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class CursorManager : MonoBehaviour
{
    public GameObject cursorTexture;
    [FormerlySerializedAs("Image")] public GameObject image;
    [FormerlySerializedAs("area_rotazioneint")] public GameObject areaRotazioneint;
    [FormerlySerializedAs("area_rotazioneest")] public GameObject areaRotazioneest;
    [FormerlySerializedAs("area_rotazioneest")] public GameObject target;
    public GameObject areaimage,areaest;
    public Camera cam;
    public bool areacreataest, areacreataint,ancoravivo;
    public static bool Colpito,caricamousecountdown;
    public static GameObject targetobject,targetImage;
    public float[] distanza;
    public bool nemico;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mouse = Input.mousePosition;
        if (Input.GetButtonDown("Fire3"))
        {
            RaycastHit hit;
            Ray lastRay = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(lastRay.origin, lastRay.direction * 180, Color.green);
            if (Physics.Raycast(lastRay, out hit))
            {
                if (!hit.collider.gameObject.CompareTag("Base")&&!hit.collider.gameObject.CompareTag("Player"))
                {
                    var o = hit.collider.gameObject;
                    targetobject = o;
                    Colpito = true;
                    ancoravivo = true;
                    if (targetobject.layer == 9)
                    {
                        nemico = true;
                    }
                }
            }
        }else if (Input.GetButtonDown("Fire2"))
        {
            Distruggi(false);
            
        }
        if (targetobject == null)
        {
            if (nemico)
            {
                Distruggi(true);
            }
            else
            {
                Distruggi(false);   
            }
            
        }

        cursorTexture.transform.position = mouse;
        if (caricamousecountdown)
        {
            image.transform.position = mouse;
            image.gameObject.SetActive(true);
        }else
        {
            image.gameObject.SetActive(false);
        }
    }

    public void Controllo(bool fuoriPortata)
    {
        
        if (ancoravivo)
        {
            if (!fuoriPortata)
            {
                SetCursorInvisible();
                Destroy(GameObject.Find("TargetEST"));
                areacreataest = false;
                if (!areacreataint)
                {
                    areacreataint = true;
                    var position = targetobject.transform.position;
                    targetImage = Instantiate(target, position,
                        target.transform.rotation);
                    var oggettovuoto=new GameObject("TargetINT1");
                    targetImage.transform.parent = oggettovuoto.transform;
                    areaimage = Instantiate(areaRotazioneint, position,
                        areaRotazioneint.transform.rotation);
                    var oggettovuoto1=new GameObject("TargetINT2");
                    areaimage.transform.parent = oggettovuoto1.transform;
                }
                else
                {
                    
                    var position = targetobject.transform.position;
                    targetImage.transform.position = new Vector3(position.x, position.y + 4, position.z);
                    areaimage.transform.position = new Vector3(position.x, position.y + 4, position.z);
                }
            }
            else
            {
                SetCursorVisible();
                Destroy(GameObject.Find("TargetINT1")); 
                Destroy(GameObject.Find("TargetINT2")); 
                areacreataint = false;
                if (!areacreataest)
                {
                    areacreataest = true;
                    var position = targetobject.transform.position;
                    areaest = Instantiate(areaRotazioneest, new Vector3(position.x, position.y + 4, position.z),
                        areaRotazioneest.transform.rotation);
                    var oggettovuoto=new GameObject("TargetEST");
                    areaest.transform.parent = oggettovuoto.transform;
                }
                else
                {

                    var position = targetobject.transform.position;
                    areaest.transform.position = new Vector3(position.x, position.y + 4, position.z);
                }
            }
        }
        else
        {
            Distruggi(true);
        }
    }

    public void Distruggi(bool generaunaltro)
    {
        var bersagli = VisualeEn.visibleTargets;
        if (generaunaltro&&bersagli.Count != 0)
        {
           distanza = new float[bersagli.Count];
           GameObject player = GameObject.Find("Triangle");
           for (int i = 0; i > bersagli.Count; i++)
           {
               Vector3 posizione = bersagli[i].transform.position;
               Vector3 posizioneplayer = player.transform.position;
               distanza[i] = Vector3.Distance(posizioneplayer, posizione);
           }
           float dismax = distanza[0];
           int pos = 0;
           for (int i = 1; i < bersagli.Count; i++)
           {
               if (dismax < distanza[i])
               {
                   dismax = distanza[i];
                   pos = i;
               }
           }
           if(bersagli[pos]!=null)
               targetobject = bersagli[pos].gameObject;
        }
        else
        {
            SetCursorVisible();
            Colpito = false;
            areacreataint = false;
            areacreataest = false;
            ancoravivo = false;
            targetobject = null;
            Destroy(GameObject.Find("TargetINT1")); 
            Destroy(GameObject.Find("TargetINT2")); 
            Destroy(GameObject.Find("TargetEST"));
        }
    }
    public void SetCursorInvisible() {
        Cursor.lockState = CursorLockMode.Locked;
        cursorTexture.SetActive(false);
        image.SetActive(false);
    }

    public void SetCursorVisible()
    {
        Cursor.lockState = CursorLockMode.None;
        cursorTexture.SetActive(true);
        image.SetActive(true);
    }
        
}
