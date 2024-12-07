
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------------Audio Source ------------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-------------Audio clip ------------------")]
    public AudioClip background;
    public AudioClip bellring;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
