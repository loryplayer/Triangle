using System;
using System.Collections;
using System.Collections.Generic;
using Blocco;
using UnityEngine;

public class Raccoltaframmento : MonoBehaviour
{
  public int frammenti;
  public void OnTriggerStay(Collider other)
  {
    if (other.gameObject.CompareTag("Frammento"))
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        frammenti++;
        GameObject.FindGameObjectWithTag("Generator").GetComponent<SpawnBlock>().Remove(false);
        MainMenu.escape = false;
        PauseMenu.pausa = false;
     //  MainMenu.PlayGame();
        Destroy(other.gameObject);
      }
    }
  }
}
