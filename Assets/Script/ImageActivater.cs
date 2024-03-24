using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageActivater : MonoBehaviour
{
    public GameObject endingPanel;
    AudioManager audioManager;

    private void Start()
    {
        endingPanel.gameObject.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene!");
        }
    }

    public void SetPanelActive()
    {
        endingPanel.gameObject.SetActive(true);
        audioManager.SparkSFX();
    }
}
