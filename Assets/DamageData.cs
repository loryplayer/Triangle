using UnityEngine;
using UnityEngine.Serialization;

public class DamageData : MonoBehaviour
{
    public float Danno;
    public GameObject gameObject;
    public GameObject optionMenu;
    public Vector3 rotation;
    public float spread;
    public GameObject[] info;
    public string desc;

    public void SetArma(Armi arma)
    {
        foreach (GameObject infos in info)
        {
            infos.GetComponent<InfoArmaCassa>().SetInfo(arma);
        }
    }
}
