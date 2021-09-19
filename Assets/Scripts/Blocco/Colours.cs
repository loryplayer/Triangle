using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colours : MonoBehaviour
{
    public Material[] Colore = new Material[5];
    public GameObject cassa;
    public Material Material;
    public int Rarità;

    void Start()
    {
        if (!gameObject.CompareTag("Crepe"))
        {
            int frammentiraccolti = GameObject.Find("Contatore")
                .GetComponent<SommaFrammenti>().Somma();
            int comunemin = 0 - frammentiraccolti;
            var comune = Random.Range(comunemin,2);
            int noncomunemin = 2 - frammentiraccolti;
            var noncomune = Random.Range(noncomunemin, 4);
            int raromin = 3 - frammentiraccolti;
            var raro = Random.Range(raromin, 6);
            int epicomin = 4 - frammentiraccolti;
            var epico = Random.Range(epicomin, 8);
            int leggendariomin = 5 - frammentiraccolti;
            var leggendario = Random.Range(leggendariomin, 10);
            int[] rarità = {comune, noncomune, raro, epico, leggendario};
            for (int c = 0; c < rarità.Length; c++)
            {
                if (0 == rarità[c])
                {
                    cassa.GetComponent<RandomGun>().Rarità = c;
                    cassa.GetComponent<Cassa>().rarita = c;
                    Rarità = c;
                    break;
                }
            }

            cassa.GetComponent<RandomGun>().Carica();
            for (int i = 0; i < Colore.Length; i++)
            {
                if (i == cassa.GetComponent<RandomGun>().Rarità)
                {
                    gameObject.GetComponent<Renderer>().material = Colore[i];
                    cassa.GetComponent<HitBox>().reset = Colore[i];
                    Material = Colore[i];
                }
            }
        }
    }

    public void CaricaMaterial(Material mat)
    {
        gameObject.GetComponent<Renderer>().material = mat;

    }
}
