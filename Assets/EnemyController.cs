using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    public GameObject playervicino;
    public NavMeshAgent agent;
    [FormerlySerializedAs("_lookRadius")] public float lookRadius;
    private float[] _distanza;
    void Update()
    {
        GameObject[] player=GameObject.FindGameObjectsWithTag("Player");
        if (player.Length!=0)
        {
            _distanza=new float[player.Length];
            for (int i = 0; i < player.Length; i++)
            {
                _distanza[i] = (Vector3.Distance(gameObject.transform.position, player[i].transform.position));
            }

            float distmin = _distanza[0];
            if (_distanza.Length > 1)
            {
                for (int i = 1; i < player.Length; i++)
                {
                    if (distmin < _distanza[i])
                    {
                        distmin = _distanza[i];
                        playervicino = player[i];
                        print(playervicino.name);
                    }
                }
            }
            else
            {
                playervicino = player[0];
            }
        }

        if (playervicino != null)
        {
            float distance = Vector3.Distance(playervicino.transform.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(playervicino.transform.position);
            }
        }
    }
}
