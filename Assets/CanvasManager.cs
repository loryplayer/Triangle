using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public bool canvason,collision,player,enemy;
    [FormerlySerializedAs("LookRadius")] public int lookRadius=20;
    [FormerlySerializedAs("CanvasGameObject")] public GameObject canvasGameObject;
    [FormerlySerializedAs("_canvas")] public GameObject canvas;
    [FormerlySerializedAs("Countdown")] public float[] countdown;
    public GameObject Attac,playergameobject;
    public OptionManu opt;
    private float[] _distanza;
    public GameObject playervicino;
    public Vector3 playervicinopos;
    public void OnCollisionEnter(Collision other)
    {            
        collision = true;
        countdown[1] = countdown[0];
        if (other.collider.gameObject.name == "Proiettile(Clone)"&&gameObject.layer!=8)
        {
            Collisione();
        }
    }
    
   public void OnParticleCollision(GameObject other)
    {
        countdown[1] = countdown[0];
        collision = true;
        if (!player)
        {
            Collisione();
        }
    }
    public void Update()
    {
        if (canvason&&!player)
        {
            GameObject[] giocatori=GameObject.FindGameObjectsWithTag("Player");
            float[] vita=new float[giocatori.Length];
            for (int i = 0; i < giocatori.Length; i++)
            {
                vita[i] = giocatori[i].GetComponent<Health>().vita;
            }

            if (giocatori.Length != 0)
            {
                _distanza = new float[giocatori.Length];
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
                        if (distmin < _distanza[i] && vita[i] > 0)
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

            float distance = Vector3.Distance(playervicinopos, transform.position);
            if (distance <= lookRadius||collision)
            {
                Vector3 position;

                float health;
                if (enemy)
                {
                    health = gameObject.GetComponent<Health>().vita / GetComponent<Health>().health;
                    position = Attac.transform.position;
                    canvas.transform.position=(new Vector3(position.x,(float) (position.y),position.z));
                    canvas.GetComponent<CanvasRotation>().player=true;
                }
                else
                {
                    health = gameObject.GetComponent<HitBox>().Vita / GetComponent<HitBox>().Health;
                     position  = gameObject.transform.position;
                     canvas.transform.position=(new Vector3(position.x,(float) (position.y+3.5),position.z));
                }
                canvas.SetActive(true);
                Image ie=canvas.GetComponent<HealthBarofObjects>().healthbar;


                ie.fillAmount = health;
                    if (health <= 0.2 && health >= 0)
                    {
                        ie.color=new Color(255,0,0);

                    }else if (health <= 0.6 && health >= 0.2)
                    {
                        ie.color=new Color(255,191,0);

                    }else if (health <= 100 && health >= 0.6)
                    {
                        ie.color=new Color(0,255,0);

                    }
            }
            else
            {
                canvas.SetActive(false);
            }
        }


        if (collision)
        {
            countdown[1] -= Time.deltaTime;
            if (countdown[1] <= 0f)
            {
                collision = false;
            }
        }
    }

    public void Collisione()
    {
        
        if (!canvason)
        {
            canvason = true;
            var transform1 = gameObject.transform;
            var position1 = transform1.position;
            canvas = Instantiate(canvasGameObject,
                new Vector3(position1.x, position1.y + 3, position1.z),
                Quaternion.identity);
            SetLayer();
            Setparent();
        }
    }

    private void SetLayer()
    {
        var tagoggetto = gameObject.tag;
        if (tagoggetto == "Blocco")
        {
            foreach (var child in canvas.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 14;
            }
        }
        else if(tagoggetto== "Barile")
        {
            foreach (var child in canvas.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 15;
            }
        }
        else if(tagoggetto== "Mattone")
        {
            foreach (var child in canvas.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 16;
            }
        }else if(tagoggetto== "Cassa")
        {
            foreach (var child in canvas.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 17;
            }
        }else if(tagoggetto== "Enemy")
        {
            foreach (var child in canvas.GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = 18;
            }
        }
        
    }

    void Setparent()
    {
        if (enemy)
        {
            canvas.transform.SetParent(Attac.transform);
            canvas.transform.LookAt(Attac.transform);
        }
        else
        {
            canvas.transform.SetParent(gameObject.transform);
        }
    }
}
