using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sprint : MonoBehaviour
{
        public Image i;
        void Update()
        {
            if (Particel.dash)
            {
                i.fillAmount = Particel.coundown[0]/Particel.coundown[1];
            }
            else 
            {
                i.fillAmount = Particel.coundown[2]/Particel.coundown[3];
            }
        }
}
