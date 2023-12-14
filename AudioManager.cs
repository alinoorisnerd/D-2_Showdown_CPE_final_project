using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;  // Include the namespace for SceneManager
using Application = UnityEngine.Application;  // Specify the full namespace for UnityEngine.Application
using Debug = UnityEngine.Debug;

public class AudioManager : MonoBehaviour
{
    // Reference to the GameObject with an AudioSource component in the Inspector
    public GameObject audioSourceGameObject;

    private AudioSource gameAudio;

    void Start()
    {
        // Check if the AudioSource GameObject is assigned
        if (audioSourceGameObject == null)
        {
            Debug.LogError("AudioSource GameObject is not assigned! Please assign an AudioSource GameObject in the Inspector.");
            return;
        }

        // Get the AudioSource component from the assigned GameObject
        gameAudio = audioSourceGameObject.GetComponent<AudioSource>();

        // Check if the AudioSource component is found
        if (gameAudio == null)
        {
            Debug.LogError("AudioSource component is not found on the assigned GameObject.");
            return;
        }

        // Play the audio when the game starts
        gameAudio.Play();
    }

    void Update()
    {
        // Check for game end condition (You might want to replace this with your specific end condition)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Stop the audio when the game ends
            gameAudio.Stop();

            // Optionally, you can add other end game logic here

            // Quit the application (you might want to replace this with your specific end game behavior)
            Application.Quit();
        }
    }
}
