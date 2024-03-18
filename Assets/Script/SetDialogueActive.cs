using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;

public class SetDialogueActive : MonoBehaviour
{
    public GameObject dialoguePrefab;

    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;

    public void SetPanelActive()
    {
        dialoguePrefab.SetActive(true);
        dialogBehaviour.BindExternalFunction("Test", DebugExternal);

        dialogBehaviour.StartDialog(dialogGraph);
    }

    private void DebugExternal()
    {
        Debug.Log("External function works!");
    }
}
