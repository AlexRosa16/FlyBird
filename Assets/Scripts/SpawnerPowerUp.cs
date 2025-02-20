using UnityEngine;

public class SpawnerPowerUp : MonoBehaviour
{
    public GameObject prefabPowerUp;
    public int tamañoPool = 3;                                 
    public float tasaGeneracion = 3f;
    public float posicionMinY = -2f;
    public float posicionMaxY = 2f;

    private GameObject[] powerUps;
    private int indiceActual = 0;
    private Vector2 posicionInicialPowerUp = new Vector2(-20, -25);        
    private float posicionXGeneracion = 10f;

    private float tiempoDesdeUltimaGeneracion;

    void Start()
    {
        tiempoDesdeUltimaGeneracion = 0f;

        powerUps = new GameObject[tamañoPool];
        for(int i = 0; i < tamañoPool; i++)
        {
            powerUps[i] = (GameObject)Instantiate(prefabPowerUp, posicionInicialPowerUp, Quaternion.identity);
        }
    }

    void Update()
    {
        tiempoDesdeUltimaGeneracion += Time.deltaTime;

        if (GameControl.instancia.juegoTerminado  == false && tiempoDesdeUltimaGeneracion >= tasaGeneracion) 
        {    
            tiempoDesdeUltimaGeneracion = 0f;

            float posicionYGeneracion = Random.Range(posicionMinY, posicionMaxY);

            powerUps[indiceActual].transform.position = new Vector2(posicionXGeneracion, posicionYGeneracion);

            indiceActual++;

            if (indiceActual >= tamañoPool) 
            {
                indiceActual = 0;
            }
        }
    }
}
