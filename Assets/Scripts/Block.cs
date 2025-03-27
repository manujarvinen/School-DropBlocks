using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    private bool isAnimating = false;
    public AudioClip[] deathSounds; // Assign 12 sound clips in Inspector
    private static AudioSource globalAudioSource;

    void Start()
    {
        // Find the global audio source in the scene (only once)
        if (globalAudioSource == null)
        {
            GameObject audioObj = GameObject.Find("SoundPlayer");
            if (audioObj != null)
                globalAudioSource = audioObj.GetComponent<AudioSource>();
        }
        Destroy(gameObject, 14f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red") && !isAnimating)
        {
            isAnimating = true;
            
            PlayDeathSound(); // Play sound

            // Create a sequence
            Sequence sequence = DOTween.Sequence();

            // Scale while keeping shape
            sequence.Join(transform.DORotate(new Vector3(0, 0, -360), 0.3f, RotateMode.FastBeyond360));
            sequence.Append(transform.DOScale(new Vector2(1.0f, 2.0f), 0.13f));
            sequence.Append(transform.DOScale(new Vector2(0.25f, 0.5f), 0.13f));
            sequence.Append(transform.DOScale(new Vector2(0.5f, 1.0f), 0.13f));

            // Rotate 360 degrees
            sequence.Join(transform.DORotate(new Vector3(0, 0, 360), 0.3f, RotateMode.FastBeyond360));

            // Scale to zero and play sound before destruction
            sequence.Join(transform.DOScale(Vector2.zero, 0.23f))
                .OnComplete(() =>
                {
                    Destroy(gameObject, 0.5f); // Delay destroy slightly to allow sound to play
                });

            sequence.Play();
        }
    }

    private void PlayDeathSound()
    {
        if (deathSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, deathSounds.Length); // Pick random sound
            globalAudioSource.PlayOneShot(deathSounds[randomIndex]); // Play sound
        }
    }
}
