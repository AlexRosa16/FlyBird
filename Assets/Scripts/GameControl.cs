using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instancia;           
    public Text textoPuntuacion;                         
    public Text textoTiempo;       
	public GameObject textoInicio;                  
    public GameObject textoGameOver;  
    private bool juegoIniciado = false;

    private int puntuacion = 0;                         
    private float tiempo = 0f;                        
    public bool juegoTerminado = false;                  
    public float velocidadDesplazamiento = -1.5f;

    void Awake()
    {
        if (instancia == null)
            instancia = this;
        else if (instancia != this)
            Destroy(gameObject);

        textoInicio.SetActive(true);  
        Time.timeScale = 0f;  
    }


    void Update()
    {
        if (!juegoIniciado && Input.GetMouseButtonDown(0))
        {
            juegoIniciado = true;
            textoInicio.SetActive(false);  // Oculta el mensaje de inicio
            Time.timeScale = 1f;  // Reactiva el tiempo del juego
        }

        if (!juegoTerminado && juegoIniciado)
        {
            tiempo += Time.deltaTime;
            textoTiempo.text = "Tiempo: " + tiempo.ToString("F2") + "s";
        }

        if (juegoTerminado && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void AumentarPuntaje(int cantidad)
    {
        puntuacion += cantidad;
        textoPuntuacion.text = "Puntos: " + puntuacion;
    }

  
    
    public void PajaroAnoto()
    {
        if (juegoTerminado)
            return;

        puntuacion++;
        textoPuntuacion.text = "Puntuación: " + puntuacion.ToString();
        
        
    }

    public void PajaroMurio()
    {
        textoGameOver.SetActive(true);
        juegoTerminado = true;
    }
    
    public int ObtenerPuntaje()
    {
        return puntuacion;
    }
}

