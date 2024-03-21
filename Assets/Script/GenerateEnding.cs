using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;
using UnityEngine.SceneManagement;

public class GenerateEnding : MonoBehaviour
{
    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private GameObject fadePanel;
    [SerializeField] private float fadeDuration = 1f;

    private Scene currentScene;

    public void MackEnding()
    {
        StartCoroutine(FadeAndLoad("MackEnding"));
    }

    public void TiaEnding()
    {
        StartCoroutine(FadeAndLoad("TiaEnding"));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        fadePanel.SetActive(true);

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

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        yield return new WaitForSeconds(0.1f); // Wait for a short time to ensure the scene is loaded

        currentScene = SceneManager.GetSceneByName(sceneName);

        elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeColor.a = alpha;
            fadePanel.GetComponent<UnityEngine.UI.Image>().color = fadeColor;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.SetActive(false);
    }
}
