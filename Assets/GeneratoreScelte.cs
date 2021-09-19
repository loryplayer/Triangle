using UnityEngine;

public class GeneratoreScelte : MonoBehaviour
{ 
   public GameObject singolo,online;

   public void Start()
   {
      Time.timeScale = 1f;
   }

   public void Singolo()
   {
      Instantiate(singolo);
      Destroy(gameObject);
   }

   public void Multigiocatore()
   {
      Instantiate(online);
      Destroy(gameObject);
   }

   public void Esci()
   {
      Application.Quit();
   }
}
