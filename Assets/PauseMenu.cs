using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool pausa,caricaopzioni,caricamenu;
    public GameObject pauseMenuUI,OptionsMenu,mainmenu,Triangle,TriangleMinimap,Weapons,Healh,Minimap,Armi;
    public static Vector3 lastposition;
    public float[] Attesa;
    public  bool stop,premuto;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!premuto&&!Armi.activeSelf)
        {
            if (!stop)
            {
                if (pausa)
                {
                    Riprendi();
                }
                else if (!pausa)
                {
                    InfoRay.hidelab = true;
                    premuto = true;
                    Pausa();
                }
            }

        }
        if (premuto)
        {
            Attesa[0] -= Time.deltaTime;
            
        }

        if (Attesa[0] <= 0)
        {
            premuto = false;
            Attesa[0] = Attesa[1];
        }
    }
    

    public void Riprendi()
    {
        if (!premuto)
        {
            pausa = false;
            Healh.SetActive(true);
            Weapons.SetActive(true);
            Minimap.SetActive(true);
            GameObject o;
            o = Triangle.gameObject;
            Triangle.GetComponent<SpriteRenderer>().enabled = true;
            TriangleMinimap.GetComponent<SpriteRenderer>().enabled = true;
            Vector3 position;
            position = lastposition;
            o.transform.position = position;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            InfoRay.showlab=true;
            InfoRay.hidelab = false;
        }
    }
    void Pausa()
    {
        if (Triangle.activeSelf)
        {
            Weapons.SetActive(false);
            Minimap.SetActive(false);
            Healh.SetActive(false);
            pauseMenuUI.SetActive(true);
            GameObject o;
            o = Triangle.gameObject;
            lastposition = Triangle.transform.position;
            Triangle.GetComponent<SpriteRenderer>().enabled = false;
            TriangleMinimap.GetComponent<SpriteRenderer>().enabled = false;
            Vector3 position;
            position = new Vector3(0, 800, 0);
            o.transform.position = (position);
            CameraFollow.Control = true;
        }
    }

    public void CaricaLeOpzioni()
    {
        caricaopzioni = true;
        OptionsMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
        stop = true;
    }

    public void Menu()
    {
        
        caricamenu = true;
        Instantiate(mainmenu);
        pauseMenuUI.SetActive(false);
        MainMenu.escape = true;
    }
}
