using UnityEngine;

public class HamFrying : MonoBehaviour
{
    // Public variables for ham materials and frying sound
    public Material goodHamMaterial;
    public Material friedHamMaterial;
    public AudioClip fryingSound;

    // Private variables to manage frying state and timer
    private bool isFrying = false;
    private float fryingTimer = 0f;

    // Called when the collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the frying pan
        if (other.CompareTag("FryingPanCollider"))
        {
            // Stick the ham to the frying pan
            transform.parent = other.transform;
            isFrying = true;
        }
    }

    // Called every frame
    private void Update()
    {
        // Check if the ham is frying
        if (isFrying)
        {
            // Increment the frying timer based on frame time
            fryingTimer += Time.deltaTime;

            // Check if frying time is more than 10 seconds
            if (fryingTimer >= 10f)
            {
                // Change material to fried ham
                GetComponent<Renderer>().material = friedHamMaterial;

                // Play frying sound
                PlayFryingSound();

                // Reset frying state
                isFrying = false;
            }
        }
    }

    // Method to play the frying sound
    private void PlayFryingSound()
    {
        // Check if AudioSource is available
        if (GetComponent<AudioSource>() == null)
        {
            // Add AudioSource component if not present
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }

        // Play the frying sound
        GetComponent<AudioSource>().PlayOneShot(fryingSound);
    }
}
