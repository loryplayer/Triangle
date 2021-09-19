using System;
using System.Globalization;
using Blocco;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float vita;
    public float health;
    public bool collisione,player,enemy;
    public GameObject Enemy,Pldead,soundtrack;
    public Image i;
    [FormerlySerializedAs("Text")] public Text text;
    public Button btlrespawn;
    public GameObject costractor,ParticelofDead,GUI_player,minimap,armicont;
    public float Danno;
    public bool CollisioneNemico;
    public TimeMenager _timeMenager;

    public void OnCollisionEnter(Collision other)
    {
        
        if (gameObject.layer == 11)
        {
            if (other.collider.gameObject.layer == 9)
            {

                collisione = true;
                Danno = other.gameObject.GetComponent<DamageData>().Danno;
                var giocatore = other.gameObject.GetComponent<DamageData>().gameObject;
                if (giocatore.GetComponent<Settaggio>().Armi.GetDescription() == "Shotgun")
                {
                    var distanza = Vector3.Distance(giocatore.transform.position, gameObject.transform.position);
                    var moltiplicatore = 1 / distanza * 15;
                    Danno *= moltiplicatore;
                }
            }else if (other.collider.gameObject.layer == 8)
            {
                CollisioneNemico = true;
            }
        }else if (gameObject.layer == 8)
        {
            
            if (other.collider.gameObject.layer == 10)
            {
                collisione = true;
                var nemico = other.gameObject.GetComponent<DamageData>().gameObject;
                Danno = other.gameObject.GetComponent<DamageData>().Danno;
                if (nemico.GetComponent<Settaggio>().Armi.GetDescription() == "Shotgun")
                {
                    var distanza = Vector3.Distance(nemico.transform.position, gameObject.transform.position);
                    var moltiplicatore = 1 / distanza * 15;
                    Danno *= moltiplicatore;
                }
            }
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (gameObject.layer != 11) return;
        if (other.collider.gameObject.layer == 8)
        {
            CollisioneNemico = false;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.name != "Splinter"&&other.name != "Fiamma(Clone)")
        {
            collisione = true;
            Danno =other.GetComponent<DamageData>().Danno*3/100;
        }
        else if (other.name == "Fiamma(Clone)"&&other.layer!=gameObject.layer)
        {
            collisione = true;
            Danno=other.GetComponent<DamageData>().Danno*3/100;
        }else if(other.layer!=gameObject.layer)
        {
            vita -= 100;
            
        }
       
    }

    private void Start()
    {
        
    
        if (player)
        {
            Pldead.SetActive(false);
            btlrespawn.onClick.AddListener(Respawn);
        }

        health = vita;
    }

    void Update()
    {
        if (player)
        {
            float vitapercentuale = vita / health;
            text.text = vita.ToString(CultureInfo.InvariantCulture) + " / 1000";
            i.fillAmount = vitapercentuale;
            if (vitapercentuale <= 0.2 && vitapercentuale >= 0)
            {
                i.color = new Color(255, 0, 0);
                //  text.color=new Color(255,0,0);
            }
            else if (vitapercentuale <= 0.6 && vitapercentuale >= 0.2)
            {
                i.color = new Color(255, 191, 0);
                // text.color=new Color(255,191,0);
            }
            else if (vitapercentuale <= 100 && vitapercentuale >= 0.6)
            {
                i.color = new Color(0, 255, 0);
                // text.color=new Color(0,255,0);
            }
        }

        if (collisione)
        {
            if (!enemy)
            {
                vita -= Danno;
            }
            else
            {
                vita -= Danno;
            }
            collisione = false;
        }

        if (Particel.dash && CollisioneNemico && !gameObject.CompareTag("Player"))
        {
            DieofEnemy();
        }
        if (vita <= 0)
        {
            if (!gameObject.CompareTag("Player"))
            {
                DieofEnemy();
            }
            else
            {
                Die();
            }
        }
    }

    public void DieofEnemy()
    {
       var redparticle =Instantiate(ParticelofDead, gameObject.transform.position, ParticelofDead.transform.rotation);
       var contenitore = GameObject.FindGameObjectWithTag("Generator").GetComponent<SpawnBlock>().Contenitore;
       redparticle.transform.SetParent(contenitore.transform);
        _timeMenager.DoSlowmotion();
        if (CursorManager.targetobject == gameObject)
        {
            var cursormanager = GameObject.FindGameObjectWithTag("Cursormanager");
            cursormanager.GetComponent<CursorManager>().Distruggi(true);
        }
        if (!gameObject.GetComponent<Settaggio>().fiameggiante)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Particel>().Destroy();
        }


    }
    public void Die()
    {
        var Infoobj = GameObject.Find("InfoLab(Clone)");
        Destroy(Infoobj);
        Cursor.visible = true;
        GameObject o=gameObject;
        o.SetActive(false);
        Pldead.SetActive(true);
        GUI_player.SetActive(false);
        minimap.SetActive(false);
        armicont.SetActive(false);
        var position = o.transform.position;
        position=new Vector3(position.x,position.y+25,position.z);
        o.transform.position = position;
 //       var cursormanager = GameObject.FindGameObjectWithTag("Cursormanager");
 //       cursormanager.GetComponent<CursorManager>().Distruggi(false);
 //       CursorManager.caricamousecountdown = false;
 //       soundtrack.GetComponent<AudioListener>().enabled = true;
    }

    public void Respawn()
    {
        GameObject o;
        var position = (o = gameObject).transform.position;
        position=new Vector3(position.x,position.y-25,position.z);
        o.transform.position = position;
        Pldead.SetActive(false);
        o.SetActive(true);
        minimap.SetActive(true);
        armicont.SetActive(true);
        GUI_player.SetActive(true);
        vita = health;
        costractor=GameObject.FindGameObjectWithTag("Generator");
        health = vita;
        costractor.GetComponent<SpawnBlock>().Remove(true);
        // soundtrack.GetComponent<AudioListener>().enabled = false;
        
        Time.timeScale = 1;
    }
}
