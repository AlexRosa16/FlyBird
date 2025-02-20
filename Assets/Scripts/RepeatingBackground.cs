using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour 
{
    private BoxCollider2D colisionadorSuelo;        
    private float longitudHorizontalSuelo;        

    private void Awake ()
    {
        colisionadorSuelo = GetComponent<BoxCollider2D>();
        longitudHorizontalSuelo = colisionadorSuelo.size.x;
    }

    private void Update()
    {
        if (transform.position.x < -longitudHorizontalSuelo)
        {
            ReposicionarFondo();
        }
    }

    private void ReposicionarFondo()
    {
        Vector2 desplazamientoSuelo = new Vector2(longitudHorizontalSuelo * 2f, 0);
        transform.position = (Vector2)transform.position + desplazamientoSuelo;
    }
}