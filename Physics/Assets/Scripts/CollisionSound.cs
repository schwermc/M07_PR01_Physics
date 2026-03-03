using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource hitSoundEffect;

    void Start()
    {
        hitSoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
        hitSoundEffect.Play();
    }
}
