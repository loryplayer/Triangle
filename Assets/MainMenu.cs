using System;
using Blocco;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Mainmenu,Healh,Optionmenu,Weapons,Minimap,generator;
    public Button btlOptions, btlBack;
    public static bool escape;
    public void PlayGame()
    {
        if (!escape)
        {
            Time.timeScale = 1f;
            Healh.SetActive(true);
            Weapons.SetActive(true);
            Minimap.SetActive(true);
            Mainmenu.SetActive(false);
        }
        else
        {
            generator.GetComponent<SpawnBlock>().Remove(true);
            escape = false;
            PauseMenu.pausa = false;
            PlayGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        Optionmenu.SetActive(true);
        Mainmenu.SetActive(false);
        Weapons.SetActive(false);
        Minimap.SetActive(false);
        Healh.SetActive(false);
    }
    public void Start()
    {
        Weapons.SetActive(false);
        Minimap.SetActive(false);
        Healh.SetActive(false);
        btlOptions.onClick.AddListener(Options);
        btlBack.onClick.AddListener(QuitGame);
    }
}
