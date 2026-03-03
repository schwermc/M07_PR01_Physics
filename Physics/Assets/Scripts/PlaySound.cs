using System.Collections;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public float waitTime = 1f;

    [SerializeField] bool _audioNotPlaying = true;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (_audioSource != null && _audioSource.clip != null)
        {
            _audioClip = _audioSource.clip;
        }
    }

    public void SoundClip()
    {
        if (_audioNotPlaying && _audioSource != null && _audioClip != null)
        {
            StartCoroutine(playAudio());
        }
    }

    IEnumerator playAudio()
    {
        _audioNotPlaying = false;
        _audioSource.PlayOneShot(_audioClip);

        yield return new WaitForSeconds(waitTime);

        _audioNotPlaying = true;
    }
}
