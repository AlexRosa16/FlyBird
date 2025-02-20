using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{
   void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.GetComponent<Bird>() != null)
        {
            GameControl.instancia.PajaroAnoto();
        }
    }
}

   