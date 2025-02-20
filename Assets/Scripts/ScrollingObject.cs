using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
    private Rigidbody2D rb2d;

    void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();

		rb2d.linearVelocity = new Vector2(GameControl.instancia.velocidadDesplazamiento, 0);
    }

    void Update()
    {
        if(GameControl.instancia.juegoTerminado == true)
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}
