using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotation : MonoBehaviour
{
    public bool player;
    private float[] _distanza;
    public GameObject playervicino;
    void Update()
    {
        if (!player)
        {
            GameObject[] giocatori=GameObject.FindGameObjectsWithTag("Player");
            float[] vita=new float[giocatori.Length];
            for (int i = 0; i < giocatori.Length; i++)
            {
                vita[i] = giocatori[i].GetComponent<Health>().vita;
            }
            
            if (giocatori.Length!=0)
            {
                _distanza=new float[giocatori.Length];
                for (int i = 0; i < giocatori.Length; i++)
                {
                    if (vita[i] > 0)
                    {
                        _distanza[i] =
                            (Vector3.Distance(gameObject.transform.position, giocatori[i].transform.position));
                    }
                }

                float distmin = _distanza[0];
                if (_distanza.Length > 1)
                {
                    for (int i = 1; i < giocatori.Length; i++)
                    {
                        if (distmin < _distanza[i]&&vita[i]>0)
                        {
                            distmin = _distanza[i];
                            playervicino = giocatori[i];
                            print(playervicino.name);
                        }
                    }
                }
                else
                {
                    playervicino = giocatori[0];
                }
            }
            var position = transform.position;
            var dir = (playervicino.transform.position - position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}
