using UnityEngine;
using System.Collections;

public class ColumnPool : MonoBehaviour 
{
    public GameObject prefabColumna;                                   
    public int tamanoGrupoColumnas = 5;                                   
    public float frecuenciaGeneracion = 3f;                                   
    public float posicionMinColumna = -1f;                                   
    public float posicionMaxColumna = 3.0f;                                   

    private GameObject[] columnas;                                   
    private int indiceActualColumna = 0;                                   

    private Vector2 posicionFueraPantalla = new Vector2(-15, -25);       
    private float posicionXGeneracion = 10f;

    private float tiempoDesdeUltimaGeneracion;

    void Start()
    {
        tiempoDesdeUltimaGeneracion = 0f;

        columnas = new GameObject[tamanoGrupoColumnas];
        for(int i = 0; i < tamanoGrupoColumnas; i++)
        {
            columnas[i] = (GameObject)Instantiate(prefabColumna, posicionFueraPantalla, Quaternion.identity);
        }
    }

    void Update()
    {
        tiempoDesdeUltimaGeneracion += Time.deltaTime;

        if (GameControl.instancia.juegoTerminado == false && tiempoDesdeUltimaGeneracion >= frecuenciaGeneracion) 
        {    
            tiempoDesdeUltimaGeneracion = 0f;

            float posicionYGeneracion = Random.Range(posicionMinColumna, posicionMaxColumna);

            columnas[indiceActualColumna].transform.position = new Vector2(posicionXGeneracion, posicionYGeneracion);

            indiceActualColumna++;

            if (indiceActualColumna >= tamanoGrupoColumnas) 
            {
                indiceActualColumna = 0;
            }
        }
    }
}