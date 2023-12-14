using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class QuitGameWithFade : MonoBehaviour
{
    public FadeScreen fader; // Reference to your fader in the Inspector

    // Function to be called when the quit button is clicked
    public void QuitGame()
    {
        // Start the coroutine to fade the screen and quit the game
        StartCoroutine(QuitWithFade());
    }

    // Coroutine to handle the fade effect and quit the game
    IEnumerator QuitWithFade()
    {
        // Trigger the fade-out effect
        fader.FadeOut();

        // Wait for the fade-out duration
        yield return new WaitForSeconds(fader.fadeDuration);

        // Quit the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

