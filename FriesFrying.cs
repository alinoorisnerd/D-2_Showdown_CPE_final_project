using UnityEngine;

public class FriesFrying : MonoBehaviour
{
    // Public materials for inspector assignment
    public Material goodFriesMaterial;  // Material for fries before frying
    public Material friedFriesMaterial; // Material for fries after frying

    // Public sound for inspector assignment
    public AudioClip fryingSound; // Sound played during frying

    private bool isFrying = false; // Flag indicating whether the fries are currently frying
    private float fryingTimer = 0f; // Timer to track the frying duration

    // Called when the collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the frying pan
        if (other.CompareTag("FryingPanCollider"))
        {
            // Stick the fries to the frying pan
            transform.parent = other.transform;
            isFrying = true; // Set the frying state to true
        }
    }

    // Called every frame
    private void Update()
    {
        // Check if the fries are frying
        if (isFrying)
        {
            // Increment the frying timer based on frame time
            fryingTimer += Time.deltaTime;

            // Check if frying time is more than 10 seconds
            if (fryingTimer >= 10f)
            {
                // Change material to fried fries
                GetComponent<Renderer>().material = friedFriesMaterial;

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
