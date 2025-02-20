using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
    public float fuerzaSalto;
    private bool estaMuerto = false;
    private bool esInvulnerable = false;

    private Animator animador;
    private Rigidbody2D rb2d;
    private AudioSource audioSource; 
    public AudioClip sonidoAleteo;  
    public AudioClip sonidoPowerUp; 
    public AudioClip sonidoGolpe;  // Clip de sonido cuando choca con un enemigo

    public IEnumerator ActivarInvulnerabilidad()
    {
        esInvulnerable = true;
        yield return new WaitForSeconds(7f);
        esInvulnerable = false;
    }

    public bool EsInvulnerable()
    {
        return esInvulnerable;
    }

    void Start()
    {
        animador = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!estaMuerto && Input.GetMouseButtonDown(0)) 
        {
			AumentarFuerzaSalto();
            animador.SetTrigger("Aleteo");
            rb2d.linearVelocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, fuerzaSalto));

            if (audioSource != null && sonidoAleteo != null) 
            {
                audioSource.PlayOneShot(sonidoAleteo);
            }
        }
    }

	public void AumentarFuerzaSalto()
	{
	int puntaje = GameControl.instancia.ObtenerPuntaje();
	fuerzaSalto = 200f + (puntaje / 2) * 15f;

	}

    public void ReproducirSonidoPowerUp()
    {
        if (audioSource != null && sonidoPowerUp != null)
        {
            audioSource.PlayOneShot(sonidoPowerUp);
        }
    }

    public void ReproducirSonidoGolpe()
    {
        if (audioSource != null && sonidoGolpe != null)
        {
            audioSource.PlayOneShot(sonidoGolpe);
        }
    }

    void OnCollisionEnter2D(Collision2D otro)
    {
        if (esInvulnerable && otro.gameObject.CompareTag("Enemigo"))
        {
            Destroy(otro.gameObject);
            return;
        }

        rb2d.linearVelocity = Vector2.zero;
        estaMuerto = true;
        animador.SetTrigger("Morir");
        
        if (sonidoGolpe != null)
        {
            audioSource.PlayOneShot(sonidoGolpe);
        }

        GameControl.instancia.PajaroMurio();
    }
}
