using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public static int speed= 40 ;

    public  Vector3 Position;
    public  Quaternion Rotation;
    public GameObject player;
    public bool fuori_portata;
    public float distance;
    public bool stop,online;
    private void Start()
    {
        if(!online)
            Time.timeScale = 0f;
    }

    void FixedUpdate()
    {
        var transform1 = transform;
        Position = transform1.position;
        Rotation = transform1.rotation;
        if (Input.GetAxis("Vertical") != 0&&!CursorManager.Colpito)
        {
            stop = false;
            Vector3 direction = new Vector3(0, 0, 0);
            direction.y = Input.GetAxis("Vertical");
            transform.Translate(Time.deltaTime * speed * direction);
        }
        else
        {
            ResetPool();
        }
        if (CursorManager.targetobject != null)
        { 
            
            distance = Vector3.Distance(CursorManager.targetobject.transform.position,
                gameObject.transform.position);
            if (CursorManager.Colpito && distance >= 10&&distance<=60)
            {
                var cursormanager = GameObject.FindGameObjectWithTag("Cursormanager");
                cursormanager.GetComponent<CursorManager>().Controllo(false);
                fuori_portata = false;
                if (Input.GetAxis("Horizontal") != 0)
                {
                    stop = false;
                    Vector3 direction = new Vector3(0, 0, 0);
                    direction.x = Input.GetAxis("Horizontal");
                    transform.Translate(Time.deltaTime * speed * direction);
                }
                else
                {
                    ResetPool();
                }
                if (Input.GetAxis("Vertical") != 0)
                {
                    stop = false;
                    Vector3 direction = new Vector3(0, 0, 0);
                    direction.y = Input.GetAxis("Vertical");
                    transform.Translate(Time.deltaTime * speed * direction);
                }else
                {
                    ResetPool();
                }
            }
            else if(distance>60)
            {
                var cursormanager = GameObject.FindGameObjectWithTag("Cursormanager");
                cursormanager.GetComponent<CursorManager>().Controllo(true);
                fuori_portata = true;
                var o = gameObject;
                var position = o.transform.position;
                transform.position.Set(position.x,0,position.z);
                if (Input.GetAxis("Vertical") !=0)     
                {
                    stop = false;
                    Vector3 direction = new Vector3(0, 0, 0);
                    direction.y = Input.GetAxis("Vertical");
                    transform.Translate(Time.deltaTime * speed * direction);
                }else
                {
                    ResetPool();
                }
            }
            else
            {
                if (Input.GetAxis("Vertical") < 0)     
                {
                    stop = false;
                    Vector3 direction = new Vector3(0, 0, 0);
                    direction.y = Input.GetAxis("Vertical");
                    transform.Translate(Time.deltaTime * speed * direction);
                }else
                {
                    ResetPool();
                }
                if (Input.GetAxis("Horizontal") != 0)
                {
                    stop = false;
                    Vector3 direction = new Vector3(0, 0, 0);
                    direction.x = Input.GetAxis("Horizontal");
                    transform.Translate(Time.deltaTime * speed * direction);
                }else
                {
                    ResetPool();
                }
            }
        }
        else
        {
            distance = 0;
        }
        
    }
    public void ResetPool()
    {
        if (!stop)
        {
            stop = true;
            GameObject o;
            Rigidbody rg = (o = gameObject).GetComponent<Rigidbody>();
            rg.velocity = Vector3.zero;
          //  var position = o.transform.position;
          //  position=new Vector3(position.x,position.z,3);
          //  o.transform.position = position;
            rg.angularVelocity = Vector3.zero;
        }
    }
    
}
    
