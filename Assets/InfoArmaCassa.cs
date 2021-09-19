using System;
using System.Globalization;
using Proiettile;
using TMPro;
using UnityEngine;

public class InfoArmaCassa : MonoBehaviour
{
    public GameObject val;
    public Armi armacassa;
    public string desc;
    public enum Info 
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

    public void SetInfo(Armi arma)
    {
        armacassa = arma;
        print(armacassa.GetDescription());
    }

    public void Update()
    {
        try
        {
            if (armacassa.GetDescription() != null)
            {
//                print(armacassa.GetDescription());
                var player = GameObject.FindGameObjectWithTag("Player");
                desc = armacassa.GetDescription();
                if (info == Info.Proiettilialsecondo)
                {
                    float sott = armacassa.Getslowness() - player.GetComponent<Settaggio>().Armi.Getslowness();
                    string valore = "";
                    Color colore;
                    if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.Getslowness() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.Getslowness() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.Getslowness()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.Getslowness() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }

                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;
                }
                else if (info == Info.Proiettili)
                {
                    float sott = armacassa.GetBullets() - player.GetComponent<Settaggio>().Armi.GetBullets();
                    string valore = "";
                    Color colore;
                    if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.GetBullets() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.GetBullets() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.GetBullets()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.GetBullets() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;
                }
                else if (info == Info.Dispersione)
                {
                    float sott = armacassa.GetSpread() - player.GetComponent<Settaggio>().Armi.GetSpread();
                    string valore = "";
                    Color colore;
                    if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.GetSpread() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.GetSpread() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.GetSpread()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.GetSpread() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;

                }
                else if (info == Info.Velocitàdelproiettile)
                {
                    float sott = armacassa.GetSpeed() - player.GetComponent<Settaggio>().Armi.GetSpeed();
                    string valore = "";
                    Color colore;
                    if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.GetSpeed() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.GetSpeed() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.GetSpeed()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.GetSpeed() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;
                }
                else if (info == Info.Danno)
                {
                    float sott = armacassa.GetDamage() - player.GetComponent<Settaggio>().Armi.GetDamage();
                    string valore = "";
                    Color colore;
                    if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.GetDamage() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.GetDamage() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.GetDamage()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.GetDamage() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;
                }
                else if (info == Info.Pesoproiettile)
                {
                    var sott = armacassa.GetHeavy() - player.GetComponent<Settaggio>().Armi.GetHeavy();
                    string valore = "";
                    Color colore;
                    if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.GetHeavy() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.GetHeavy() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.GetHeavy()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.GetHeavy() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;
                }
                else if (info == Info.Penetrazione)
                {
                    float sott = armacassa.GetOvercome() - player.GetComponent<Settaggio>().Armi.GetOvercome();
                    string valore = "";
                    Color colore;
                    if (sott > 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.green;
                        valore = (armacassa.GetOvercome() + "  + (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else if (sott < 0 && player.GetComponent<Settaggio>().Armi.Getslowness() != 0)
                    {
                        colore = Color.red;
                        valore = (armacassa.GetOvercome() + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        colore = Color.white;
                        valore = (armacassa.GetOvercome()).ToString(CultureInfo.InvariantCulture);
                    }
                    if (armacassa.GetOvercome() == 0)
                    {
                        colore = Color.red;
                        valore = (" - " + "    (" + sott+")").ToString(CultureInfo.InvariantCulture);
                    }
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                    val.GetComponent<TextMeshProUGUI>().color = colore;
                }
                else if (info == Info.Descrizione)
                {
                    var valore = armacassa.GetDescription().ToString(CultureInfo.InvariantCulture);
                    val.GetComponent<TextMeshProUGUI>().text = valore;
                }
            }
        }
        catch (NullReferenceException)
        { }
    }
    
}
