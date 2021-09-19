
using System;
using System.Linq;
using Proiettile;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Blocco
{
    public class SpawnBlock : MonoBehaviour
    {
        public GameObject cubo,altare;
        public GameObject Base;
        public GameObject cassa;
        public GameObject Costructor;
        public GameObject Barile,Nemico;
        [FormerlySerializedAs("Passerella")] public GameObject passerella;
        [FormerlySerializedAs("Muro")] public GameObject muro;
        private int _i, _x, _z,indicepos=0;
        private int _xb, _zb, _xc, _zc, _xcos, _zcos, playerToSpawn, altaretospaw = 1,indicegiocatori=0;
        public NavMeshSurface surface;
        public GameObject player;
        public bool PlayerSpawned,altarecreated;
        public GameObject Contenitore;
        public bool single,fermadispawnare,fine=true;
        public Vector3 coordinataplayer;
        public float[][] matriceposizioni=new float[32][];
        public GameObject[] giocatori;
        void Start()
        {
            Randombase();
        }

        public void Remove(bool fine)
        {
            giocatori = GameObject.FindGameObjectsWithTag("Player");
            foreach (var giocatore in giocatori)
            {
                giocatore.GetComponent<Settaggio>().Reset(fine);
                giocatore.GetComponent<Renderer>().enabled = true;
            }

            this.fine = fine;
            PlayerSpawned = false;
            altarecreated = false;
            indicepos = 0;
            matriceposizioni=new float[32][];
            Destroy(Contenitore);
            Randombase();
        }
        public void Randombase()
        {
            giocatori = GameObject.FindGameObjectsWithTag("Player");
            Contenitore= new GameObject("Contenitore");
            Contenitore.tag = "Contenitore";
            playerToSpawn= Random.Range(0, 6);
            var gambase=Instantiate(Base,new Vector3(0,0,0),Base.transform.rotation);
            gambase.transform.parent = Contenitore.transform;
            Randombox(0, 0);
            int i1 = Random.Range(1, 4);
            int dispari = 1;
            for (int e = 1; e <= i1; e++)
            {
                int ran = 0;
                for (int rip = 0; rip <= i1; rip++)
                {
                    ran = Random.Range(i1+1,i1-1);
                }
                var gameobject1 = Instantiate(passerella, new Vector3(0, 0, (140 * dispari)),
                        passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)), transform);
                    gameobject1.transform.parent = Contenitore.transform;
                    var gameobject2= Instantiate(Base, new Vector3(0, -0, (280 * e)), Base.transform.rotation,transform);
                    gameobject2.transform.parent = Contenitore.transform;
                    playerToSpawn= Random.Range(0, 6);
                Randombox(0, (280 * e));

                if (i1 == ran)
                {
                    var gameobject3= Instantiate(passerella, new Vector3(-140, -0, (280 * e)),
                        passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject3.transform.parent = Contenitore.transform;
                    var gameobject4= Instantiate(Base, new Vector3(-280, -0, (280 * e)), Base.transform.rotation,transform);
                    gameobject4.transform.parent = Contenitore.transform;
                    var gameobject5= Instantiate(muro, new Vector3(+100, 5, (280 * e)),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject5.transform.parent = Contenitore.transform;
                    var gameobject6= Instantiate(muro, new Vector3(-380, 5, (280 * e)),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject6.transform.parent = Contenitore.transform;
                    var gameobject7= Instantiate(muro, new Vector3(-280, 5, (280 * e) + 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject7.transform.parent = Contenitore.transform;
                    var gameobject8= Instantiate(muro, new Vector3(-280, 5, (280 * e) - 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject8.transform.parent = Contenitore.transform;
                    playerToSpawn= Random.Range(0, 6);
                    Randombox(-280, (280 * e));
                }
                else
                {
                    Quaternion rotation;
                    var gameobject9= Instantiate(muro, new Vector3(-100, 5, (280 * e)), Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject9.transform.parent = Contenitore.transform;
                    var gameobject10= Instantiate(muro, new Vector3(100, 5, (280 * e)), rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject10.transform.parent = Contenitore.transform;
                    muro.transform.rotation = rotation;

                }

                if (e == i1)
                {
                    var gameobject11= Instantiate(muro, new Vector3(0, 5, (280*e)+100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject11.transform.parent = Contenitore.transform;

                }

                dispari = dispari + 2;
            }

            dispari = 1;
            int i2 = Random.Range(1, 4);
            for (int e = 1; e <= i2; e++)
            {
                int ran = 0;
                for (int rip = 0; rip <= i2; rip++)
                {
                    ran = Random.Range(i2+1,i2-1);
                }

                var gameobject12= Instantiate(passerella, new Vector3((140 * dispari), -0, 0),
                    passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                gameobject12.transform.parent = Contenitore.transform;
                var gameobject13= Instantiate(Base, new Vector3((280 * e), -0, 0), Base.transform.rotation,transform);
                gameobject13.transform.parent = Contenitore.transform;
                playerToSpawn= Random.Range(0, 6);
                Randombox((280 * e), 0);
                if (i1 == ran)
                {
                    var gameobject14= Instantiate(passerella, new Vector3((280 * e), -0, 140),
                        passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject14.transform.parent = Contenitore.transform;
                    var gameobject15= Instantiate(Base, new Vector3((280 * e), -0, 280), Base.transform.rotation,transform);
                    gameobject15.transform.parent = Contenitore.transform;
                    var gameobject16= Instantiate(muro, new Vector3((280 * e), 5, -100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject16.transform.parent = Contenitore.transform;
                    var gameobject17= Instantiate(muro, new Vector3((280 * e), 5, 380),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject17.transform.parent = Contenitore.transform;
                    var gameobject18= Instantiate(muro, new Vector3((280 * e) + 100, 5, 280),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject18.transform.parent = Contenitore.transform;
                    var gameobject19= Instantiate(muro, new Vector3((280 * e) - 100, 5, 280),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject19.transform.parent = Contenitore.transform;
                    playerToSpawn= Random.Range(0, 6);
                    Randombox((280 * e), 280);
                }
                else
                {
                    var gameobject20= Instantiate(muro, new Vector3((280 * e), 5, -100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject20.transform.parent = Contenitore.transform;
                    var gameobject21= Instantiate(muro, new Vector3((280 * e), 5, 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject21.transform.parent = Contenitore.transform;

                }

                if (e == i2)
                {
                    var gameobject22= Instantiate(muro, new Vector3((280 * e) + 100, 5, 0),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject22.transform.parent = Contenitore.transform;

                }

                dispari = dispari + 2;
            }

            dispari = 1;
            int i3 = Random.Range(1, 4);
            for (int e = 1; e <= i3; e++)
            {
                int ran = 0;
                for (int rip = 0; rip <= i1; rip++)
                {
                    ran = Random.Range(i3+1,i3-1);
                }

                var gameobject23= Instantiate(passerella, new Vector3((-140 * dispari), -0, 0),
                    passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                gameobject23.transform.parent = Contenitore.transform;
                var gameobject24= Instantiate(Base, new Vector3((-280 * e), -0, 0), Base.transform.rotation,transform);
                gameobject24.transform.parent = Contenitore.transform;
                playerToSpawn= Random.Range(0, 6);
                if (!altarecreated)
                {
                    altaretospaw = 0;
                }
                Randombox((-280 * e), 0);
                if (i1 == ran)
                {

                    var gameobject25= Instantiate(passerella, new Vector3((-280 * e), -0, -140),
                        passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject25.transform.parent = Contenitore.transform;
                    var gameobject26= Instantiate(Base, new Vector3((-280 * e), -0, -280), Base.transform.rotation,transform);
                    gameobject26.transform.parent = Contenitore.transform;
                    var gameobject27= Instantiate(muro, new Vector3((-280 * e), 5, 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject27.transform.parent = Contenitore.transform;
                    var gameobject28= Instantiate(muro, new Vector3((-280 * e), 5, -380),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject28.transform.parent = Contenitore.transform;
                    var gameobject29= Instantiate(muro, new Vector3((-280 * e) + 100, 5, -280),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject29.transform.parent = Contenitore.transform;
                    var gameobject30= Instantiate(muro, new Vector3((-280 * e) - 100, 5, -280),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject30.transform.parent = Contenitore.transform;
                    playerToSpawn= Random.Range(0, 6);
                    altaretospaw = Random.Range(0, 4);
                    Randombox((-280 * e), -280);
                }
                else
                {
                    var gameobject31= Instantiate(muro, new Vector3((-280 * e), 5, -100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject31.transform.parent = Contenitore.transform;
                    var gameobject32= Instantiate(muro, new Vector3((-280 * e), 5, 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject32.transform.parent = Contenitore.transform;

                }

                if (e == i3)
                {
                    var gameobject33= Instantiate(muro, new Vector3((-280 * e) - 100, 5, 0),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject33.transform.parent = Contenitore.transform;

                }

                dispari = dispari + 2;
            }

            dispari = 1;
            int i4 = Random.Range(1, 4);
            for (int e = 1; e <= i4; e++)
            {
                int ran = 0;
                for (int rip = 0; rip <= i1; rip++)
                {
                    ran = Random.Range(i4+1,i4-1);
                }

                var gameobject34= Instantiate(passerella, new Vector3(0, 0, (-140 * dispari)),
                    passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                gameobject34.transform.parent = Contenitore.transform;
                var gameobject35= Instantiate(Base, new Vector3(0, -0, (-280 * e)), Base.transform.rotation,transform);
                gameobject35.transform.parent = Contenitore.transform;
                if (!PlayerSpawned)
                {
                    playerToSpawn = 0;
                }
                Randombox(0, (-280 * e));
                
                if (i1 == ran)
                {


                    var gameobject36= Instantiate(passerella, new Vector3(140, 0, (-280 * e)),
                        passerella.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject36.transform.parent = Contenitore.transform;
                    var gameobject37= Instantiate(Base, new Vector3(280, -0, (-280 * e)), Base.transform.rotation,transform);
                    gameobject37.transform.parent = Contenitore.transform;
                    var gameobject38= Instantiate(muro, new Vector3(-100, 5, (-280 * e)),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject38.transform.parent = Contenitore.transform;
                    var gameobject39= Instantiate(muro, new Vector3(380, 5, (-280 * e)),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject39.transform.parent = Contenitore.transform;
                    var gameobject40= Instantiate(muro, new Vector3(280, 5, (-280 * e) + 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject40.transform.parent = Contenitore.transform;
                    var gameobject41= Instantiate(muro, new Vector3(280, 5, (-280 * e) - 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject41.transform.parent = Contenitore.transform;
                    playerToSpawn= Random.Range(0, 6);
                    altaretospaw = Random.Range(0, 4);
                    Randombox(280, (-280 * e));
                }
                else
                {
                    var gameobject42= Instantiate(muro, new Vector3(-100, 5, (-280 * e)),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject42.transform.parent = Contenitore.transform;
                    var gameobject43= Instantiate(muro, new Vector3(100, 5, (-280 * e)),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)),transform);
                    gameobject43.transform.parent = Contenitore.transform;
                }

                if (e == i4)
                {
                    var gameobject44= Instantiate(muro, new Vector3(0, 5, (-280 * e) - 100),
                        muro.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)),transform);
                    gameobject44.transform.parent = Contenitore.transform;
                }

                dispari = dispari + 2;
            }

            altarecreated = false;
            surface.BuildNavMesh();
//            Debug.Log(matriceposizioni.ToArray());
        }

        void Randombox(int xbase, int zbase)
        {
            indicepos++;
            matriceposizioni[indicepos]=new float[]{xbase,zbase}; 
            if (altaretospaw == 0 && !altarecreated)
            {
                _x = Random.Range(-10, 10);
                _z = Random.Range(-10, 10);
                var altare = Instantiate(this.altare,new Vector3(xbase+_x,(float) 6.5,zbase+_z),this.altare.transform.rotation);
                altare.transform.parent = Contenitore.transform;
                altarecreated = true;
            }
            else
            {
                _xc = Random.Range(-30, +30);
                _xc = Random.Range(-30, +30);
                var gameobject48= Instantiate(cassa,  new Vector3(xbase + _xc, 4, zbase + _zc), cassa.transform.rotation,transform);
                gameobject48.transform.parent = Contenitore.transform;
                if (playerToSpawn == 0&&!PlayerSpawned)
                {
                    PlayerSpawned = true;
                    coordinataplayer =new Vector3(xbase, 3, zbase);
                    if (single&&!fermadispawnare)
                    {
                        fermadispawnare = true;
                        Instantiate(player,coordinataplayer  , player.transform.rotation.normalized);
                    }else
                    if(!fine)
                    {
                        giocatori[Random.Range(0, giocatori.Length)].transform.position = coordinataplayer;
                        if (giocatori.Length > 0)
                        {
                            PlayerSpawned = false;
                        }
                    }
                    else
                    {
                        giocatori[indicegiocatori].transform.position = coordinataplayer;
                    }

                }
                else
                {
                    int randomenemycount = Random.Range(1, 5);
                    for (int i = 0; i < randomenemycount; i++)
                    {
                        _x = Random.Range(-30, 30);
                        _z = Random.Range(-30, 30);
                        var gameobject45 = Instantiate(Nemico, new Vector3(xbase + _x, 4, zbase + _z),
                            Nemico.transform.rotation, transform);
                        gameobject45.SetActive(true);
                        gameobject45.transform.parent = Contenitore.transform;
                    }
                }
            }
            _i = 0;
            do
            {
                _x = Random.Range(-50, 50);
                _z = Random.Range(-50, 50);
                var gameobject46= Instantiate(cubo, new Vector3(xbase + _x, 4, zbase + _z), cubo.transform.rotation,transform);
                gameobject46.transform.parent = Contenitore.transform;
                _i++;
            } while (_i < 4);
            for (int i = 0; i < Random.Range(5,8); i++)
            {
                _x = Random.Range(-60, 60);
                _z = Random.Range(-60, 60);
                var gameobject47= Instantiate(Barile, new Vector3(xbase + _x, 4, zbase + _z), Barile.transform.rotation,transform);  
                gameobject47.transform.parent = Contenitore.transform;
            }
            int ex=1,ez=1;
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    ex = -1;
                    ez = 1;
                }
                else if(i==1)
                {
                    ex = 1;
                    ez = -1;
                }
                else if(i==2)
                {
                    ex = -1; 
                    ez = -1;
                }
                else if(i==3)
                {
                    ex = 1;
                    ez = 1;
                }

                for (int j = 0; j < 4; j++)
                {
                    _xcos = Random.Range(-70, 0)*ex;
                    _zcos = Random.Range(70, 0)*ez;
                    var gameobject49= Instantiate(Costructor, new Vector3(xbase + _xcos, 3, zbase + _zcos), Costructor.transform.rotation,transform);
                    gameobject49.transform.parent = Contenitore.transform;
                }
            }

            if (indicegiocatori+1<giocatori.Length)
            {
                indicegiocatori++;
            }
        }
        
    }
}
