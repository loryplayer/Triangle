using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFra : MonoBehaviour
{
    // Start is called before the first frame update
    public float forzaminima;
    public float forzamassima;
    public float raggio;
    void Start()
    {
        GeneraEsplosione();
    }


    public void GeneraEsplosione()
    {
        foreach (Transform frattura  in transform)
        {
            var rb = frattura.GetComponent<Rigidbody>();
            if (rb != null)
            {
               // print("esposione");
                rb.AddExplosionForce(Random.Range(forzaminima,forzamassima),transform.position,raggio);
            }
        }
    }
}
