using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionManu : MonoBehaviour
{
    public  bool blocchi,barili,nessuno,tuttiGliOggetti=true,muretti,casse,nemici;
    public Button  btlBackmenu;
    public GameObject pausemenu,mainmenu;
    public GameObject camera;
    public void Start()
    {
        btlBackmenu.onClick.AddListener(backmenu);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backmenu();
        }
        if (blocchi)
        {
            camera.GetComponent<Camera>().cullingMask |= 14;
        }
        else if(!tuttiGliOggetti)
        {
            camera.GetComponent<Camera>().cullingMask &= ~14;
        }
        if (barili)
        {
            camera.GetComponent<Camera>().cullingMask |= 15;
        }
        else if(!tuttiGliOggetti)
        {
            camera.GetComponent<Camera>().cullingMask &= ~15;
        }
        if (muretti)
        {
            camera.GetComponent<Camera>().cullingMask |= 16;
        }
        else if(!tuttiGliOggetti)
        {
            camera.GetComponent<Camera>().cullingMask &= ~16;
        }
        if (casse)
        {
            camera.GetComponent<Camera>().cullingMask |= 17;
        }
        else if(!tuttiGliOggetti)
        {
            camera.GetComponent<Camera>().cullingMask &= ~17;
        }
        if (nemici)
        {
            camera.GetComponent<Camera>().cullingMask |= 18;
        }
        else if(!tuttiGliOggetti)
        {
            camera.GetComponent<Camera>().cullingMask &= ~18;
        }

        if (tuttiGliOggetti)
        {
            camera.GetComponent<Camera>().cullingMask |= 14;
            camera.GetComponent<Camera>().cullingMask |= 15;
            camera.GetComponent<Camera>().cullingMask |= 16;
            camera.GetComponent<Camera>().cullingMask |= 17;
            camera.GetComponent<Camera>().cullingMask |= 18;
        }

        if (nessuno)
        {
            camera.GetComponent<Camera>().cullingMask &= ~14;
            camera.GetComponent<Camera>().cullingMask &= ~15;
            camera.GetComponent<Camera>().cullingMask &= ~16;
            camera.GetComponent<Camera>().cullingMask &= ~17;
            camera.GetComponent<Camera>().cullingMask &= ~18;
        }
    }

    void backmenu()
    {
        if (PauseMenu.pausa)
        {
            pausemenu.SetActive(true);
            gameObject.SetActive(false);
            pausemenu.GetComponent<PauseMenu>().stop = false;
        }
        else
        {
            mainmenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void Blocchi(bool stato)
    {
        blocchi = stato;
        
    }

    public void Barili(bool stato)
    {
        barili = stato;

    }
    public void Nessuno(bool stato)
    {
        nessuno = stato;
    }
    public void Tutti_gli_Oggetti(bool stato)
    {
        tuttiGliOggetti = stato;
    }
    public void Muretti(bool stato)
    {
        muretti = stato;
    }
    public void Casse(bool stato)
    {
        casse = stato;
    }
    public void Nemici(bool stato)
    {
        nemici = stato;
    }

}
