using UnityEngine;

public class AudioRandomPitch : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to choose from
    public float minPitch = 0.8f; // Minimum pitch value
    public float maxPitch = 1.2f; // Maximum pitch value

    private void Start()
    {
        
        PlayRandomSound();
    }
    public void PlayRandomSound()
    {
        var audioSource = GetComponent<AudioSource>();
        if (audioClips.Length == 0)
        {
            Debug.LogError("No audio clips assigned!");
            return;
        }

        // Choose a random audio clip
        int randomIndex = Random.Range(0, audioClips.Length);
        AudioClip clipToPlay = audioClips[randomIndex];



        // Randomize pitch
        float randomPitch = Random.Range(minPitch, maxPitch);


        audioSource.clip = clipToPlay;
        audioSource.pitch = randomPitch;
        

        // Play the audio
        audioSource.Play();
        

        // Clean up after the audio has finished playing
        Destroy(this.gameObject, clipToPlay.length);
    }
}