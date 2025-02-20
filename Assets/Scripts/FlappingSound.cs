using UnityEngine;

public class FlappingSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFlap()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }
}