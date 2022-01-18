using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    public static AudioManager Instance;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void Play(int i)
    {
        _audioSource.PlayOneShot(clips[i]);
    }
}