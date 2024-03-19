using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;
using UnityEngine.Events;  

public class SetDialogueActive : MonoBehaviour
{
    public GameObject dialoguePrefab;
    public bool hasAlreadySpoken = false;
    [SerializeField] private DialogBehaviour dialogBehaviour2;
    [SerializeField] private DialogNodeGraph dialogGraph2;

    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private UnityEvent events;

    public void SetPanelActive()
    {
        if(hasAlreadySpoken == false)
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.BindExternalFunction("end first dialogue", FirstDialogueEnd);


            dialogBehaviour.StartDialog(dialogGraph);
        }
        else if(hasAlreadySpoken == true)
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
    }

    private void DebugExternal()
    {
        Debug.Log("External function works!");
    }
}
