using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Rotation : MonoBehaviour
{
    public GameObject enemyprefab;
    public float rotation1;
    private float[] _distanza;

    void FixedUpdate()
    {
        if (gameObject.layer == 8)
        {
            if (CursorManager.Colpito && CursorManager.targetobject != null && !gameObject.GetComponent<Movement>().fuori_portata)
            {
                var position = CursorManager.targetobject.transform.position;
                var dir = (position - gameObject.transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, -90, dir.z));
                Quaternion rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);
                var transform1 = transform;
                transform1.rotation = rotation;
                rotation1 = transform1.localEulerAngles.y;
                var o = gameObject;
                var posg = o.transform.position;
                o.transform.position = new Vector3(posg.x, 3, posg.z);
            }
            else
            {
                Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                dir = new Vector3((float) (dir.x), dir.y, (float) (dir.z));
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle - 90));
            }
        }
        if (gameObject.layer == 11)
        {
            GameObject playervicino=gameObject.GetComponent<EnemyController>().playervicino;
            GameObject[] player=GameObject.FindGameObjectsWithTag("Player");
            if (player.Length!=0)
            {
                if (playervicino != null)
                {
                    float distance = Vector3.Distance(gameObject.transform.position, playervicino.transform.position);
                    if (distance < 80)
                    {
                        var position = gameObject.transform.position;
                        var dir = (playervicino.transform.position - position).normalized;
                        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
                        Quaternion rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
                        var transform1 = transform;
                        transform1.rotation = rotation;
                        rotation1 = transform1.localEulerAngles.y;
                        enemyprefab.transform.position = new Vector3(position.x, 3, position.z);
                    }
                }
            }
        }
    }


}
