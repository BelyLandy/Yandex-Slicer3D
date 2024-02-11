using UnityEngine;

public class DoSound : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] AudioClip[] audioClips = new AudioClip[2];

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DoSoundMethod()
    {
        _audioSource.clip = audioClips[Random.Range(0, 2)];
        _audioSource.Play();
    }
}
