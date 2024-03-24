using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private float fadeDuration = 1f;

    AudioManager audioManager;

    private void Start()
    {
        // Ensure the fade panel is inactive at the start
        fadePanel.SetActive(false);

        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene!");
        }
    }

    public void GoToScene()
    {
        StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
        // Activate the fade panel
        fadePanel.SetActive(true);
        audioManager.PaperSFX();

        // Fade in effect
        float elapsedTime = 0f;
        Color fadeColor = fadePanel.GetComponent<UnityEngine.UI.Image>().color;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeColor.a = alpha;
            fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Save the last scene before loading the new scene
        DetermineSpawnPoint.SaveLastScene();

        // Load the new scene asynchronously
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        // Wait for a short time to ensure the scene is loaded
        yield return new WaitForSeconds(0.1f);

        // Fade out effect
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeColor.a = alpha;
            fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Deactivate the fade panel
        fadePanel.SetActive(false);
    }
}
