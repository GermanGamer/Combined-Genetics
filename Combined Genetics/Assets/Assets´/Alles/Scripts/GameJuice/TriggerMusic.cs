using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public AudioSource[] audioSources;
    private int currentIndex = 0;

    private void Start()
    {
        // Ensure all audio sources are initially stopped
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayNextAudioSource();
        }
    }

    private void PlayNextAudioSource()
    {
        // Stop the current audio source if it's playing
        if (currentIndex > 0 && audioSources[currentIndex - 1].isPlaying)
        {
            StartCoroutine(StopAndPlayNext());
        }
        else
        {
            PlayCurrent();
        }
    }

    private void PlayCurrent()
    {
        // Play the next audio source if there is one
        if (currentIndex < audioSources.Length)
        {
            audioSources[currentIndex].Play();

            // Wait for the duration of the current audio source
            StartCoroutine(WaitForAudioDuration(audioSources[currentIndex].clip.length));

            currentIndex++;
        }
        else
        {
            // Reset the index if we've reached the end of the array
            currentIndex = 0;
        }
    }

    private System.Collections.IEnumerator StopAndPlayNext()
    {
        // Wait until the current audio source has stopped playing
        yield return new WaitUntil(() => !audioSources[currentIndex - 1].isPlaying);

        // Stop the previous audio source (just to be sure it's stopped)
        audioSources[currentIndex - 1].Stop();

        // Play the next audio source
        PlayCurrent();
    }

    private System.Collections.IEnumerator WaitForAudioDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        // After waiting for the duration, trigger the next audio source
        PlayNextAudioSource();
    }
}
