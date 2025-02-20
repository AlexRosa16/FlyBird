using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip sonidoGolpe;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        Bird bird = otro.GetComponent<Bird>();

        if (bird != null)
        {
            if (bird.EsInvulnerable()) 
            {
                Destroy(gameObject);
            }
            else
            {
                if (sonidoGolpe != null && audioSource != null)
                {
                    audioSource.PlayOneShot(sonidoGolpe);
                }
                GameControl.instancia.PajaroMurio();
            }
        }
    }
}
