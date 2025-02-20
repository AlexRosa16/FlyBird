using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioClip sonidoPowerUp; // Clip de sonido
    public ParticleSystem efectoParticulas; // Efecto de partículas

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        Bird bird = otro.GetComponent<Bird>();
        if (bird != null)
        {	GameControl.instancia.AumentarPuntaje(1); // Actualizar puntaje en GameControl
            bird.AumentarFuerzaSalto();
            bird.StartCoroutine(bird.ActivarInvulnerabilidad());
            bird.ReproducirSonidoPowerUp(); // Reproduce el sonido en el pájaro
            
            // Si hay un efecto de partículas, instanciarlo antes de destruir el PowerUp
            if (efectoParticulas != null)
            {
                Instantiate(efectoParticulas, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
