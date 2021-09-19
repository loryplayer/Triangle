using System;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;

public class ArmiManager : MonoBehaviour
{
    public  String[] Description={"Rifle","Shotgun","Sniper","Flamethrower"} ;
    public  GameObject[] armi;
    public int OUT;
    [FormerlySerializedAs("_player")] public GameObject player;
    private Settaggio _settaggio;
    void Update()
    {
        _settaggio = player.GetComponent<Settaggio>();
        if (OUT == 1&&!BoxOpener.first)
        {
            
            for (int e=0; e<Description.Length;e++)
            {
                if (_settaggio.armaupdate[0].GetDescription() == Description[e])
                {
                    armi[e].SetActive(true);
                }
                else
                {
                    armi[e].SetActive(false);
                }
            }
        }else
        if (OUT == 2&&_settaggio.cambioprimaarma)
        {
            for (int e=0; e<Description.Length;e++)
            {
                if (_settaggio.armaupdate[1].GetDescription() == Description[e])
                {
                    Debug.Log("arma "+_settaggio.armaupdate[1].GetDescription());
                    armi[e].SetActive(true);
                    break;
                }
                armi[e].SetActive(false);
            }

        }
        else
        {
            for (int e=0; e<Description.Length;e++)
            {
                armi[e].SetActive(false);
            }
        }
    }
}
