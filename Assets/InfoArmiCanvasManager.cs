using UnityEngine;

public class InfoArmiCanvasManager : MonoBehaviour
{
    public GameObject canvas;
    public bool premuto;
    void Update()
    {
        if (!PauseMenu.pausa)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!premuto)
                {
                    canvas.SetActive(true);
                    premuto = true;
                    Time.timeScale = 0;
                }
                else
                {
                    premuto = false;
                    canvas.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && premuto)
            {
                canvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
