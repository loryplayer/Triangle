
using System.Globalization;
using Proiettile;
using TMPro;
using UnityEngine;

public class ValInfo : MonoBehaviour
{
    public GameObject val,player;
    private Settaggio _settaggio;
    public int indice;
    public enum Type
    {
    Type1,
    Type2
    }

    public Type tipo;
    public enum Info // your custom enumeration
    {
        Proiettilialsecondo, 
        Proiettili, 
        Dispersione,
        Velocitàdelproiettile,
        Danno,
        Pesoproiettile,
        Penetrazione,
        Descrizione
    };

    public Info info;
    void Update()
    {
        _settaggio = player.GetComponent<Settaggio>();
        if (tipo == Type.Type1)
        {
            indice = 0;
        }else if (tipo == Type.Type2)
        {
            indice = 1;
        }

        switch (info)
        {
            case Info.Proiettilialsecondo:
            {
                var valore = _settaggio.Narma[indice].Getslowness().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
            case Info.Proiettili:
            {
                var valore = _settaggio.Narma[indice].GetBullets().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                //  print(valore+" proiettili");
                val.GetComponent<TextMeshProUGUI>().text = valore;
                break;
            }
            case Info.Dispersione:
            {
                var valore = _settaggio.Narma[indice].GetSpread().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
            case Info.Velocitàdelproiettile:
            {
                var valore = _settaggio.Narma[indice].GetSpeed().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
            case Info.Danno:
            {
                var valore = _settaggio.Narma[indice].GetDamage().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
            case Info.Pesoproiettile:
            {
                var valore = _settaggio.Narma[indice].GetHeavy().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
            case Info.Penetrazione:
            {
                var valore = _settaggio.Narma[indice].GetOvercome().ToString(CultureInfo.InvariantCulture);
                if (valore == "0")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
            case Info.Descrizione:
            {
                var valore = _settaggio.Narma[indice].GetDescription().ToString(CultureInfo.InvariantCulture);
                if (valore == " ")
                {
                    valore = " - ";
                }
                val.GetComponent<TextMeshProUGUI>().text =valore ;
                break;
            }
        }
    }
}
