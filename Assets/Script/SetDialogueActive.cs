using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;
using UnityEngine.Events;

public class SetDialogueActive : MonoBehaviour
{
    public GameObject dialoguePrefab;
    [SerializeField] private DialogBehaviour dialogBehaviour2;
    [SerializeField] private DialogNodeGraph dialogGraph2;

    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private UnityEvent events;

    private bool hasAlreadySpoken;

    private void Start()
    {
        // Load the value of hasAlreadySpoken from PlayerPrefs when the scene starts
        hasAlreadySpoken = PlayerPrefs.GetInt("HasAlreadySpoken", 0) == 1;
    }

    public void SetPanelActive()
    {
        if (!hasAlreadySpoken)
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.BindExternalFunction("end first dialogue", FirstDialogueEnd);
            dialogBehaviour.StartDialog(dialogGraph);
        }
        else
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour2.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour2.BindExternalFunction("function", Function);
            dialogBehaviour2.StartDialog(dialogGraph2);
        }
    }

    private void Function()
    {
        events.Invoke();
    }

    public void FirstDialogueEnd()
    {
        hasAlreadySpoken = true;
        // Save the value of hasAlreadySpoken to PlayerPrefs
        PlayerPrefs.SetInt("HasAlreadySpoken", 1);
    }

    private void DebugExternal()
    {
        Debug.Log("External function works!");
    }
}
