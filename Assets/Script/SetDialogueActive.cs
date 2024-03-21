using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;
using UnityEngine.Events;

public class SetDialogueActive : MonoBehaviour
{
    public GameObject dialoguePrefab;

    [SerializeField] private DialogBehaviour dialogBehaviour;
    [SerializeField] private DialogNodeGraph dialogGraph;
    [SerializeField] private DialogNodeGraph dialogGraph2;
    [SerializeField] private DialogNodeGraph dialogGraph3;
    [SerializeField] private DialogNodeGraph dialogGraph4;
    [SerializeField] private UnityEvent events;
    [SerializeField] private UnityEvent events2;

    private bool hasAlreadySpokenToMack;
    private bool hasAlreadySpokenToTia;
    private bool hasAlreadySpokenToNPC;

    void Start()
    {
        // Reset PlayerPrefs data for testing purposes
        //PlayerPrefs.DeleteAll();

        // Load the value of hasAlreadySpoken from PlayerPrefs when the scene starts
        hasAlreadySpokenToMack = PlayerPrefs.GetInt("HasAlreadySpokenToMack", 0) == 1;
        hasAlreadySpokenToTia = PlayerPrefs.GetInt("HasAlreadySpokenToTia", 0) == 1;
        hasAlreadySpokenToNPC = PlayerPrefs.GetInt("HasAlreadySpokenToNPC", 0) == 1;
    }


    public void SetMackPanelActive()
    {
        if (!hasAlreadySpokenToMack)
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.BindExternalFunction("end mack intro dialogue", MackIntroDialogueEnd);
            dialogBehaviour.StartDialog(dialogGraph);
        }
        else
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.StartDialog(dialogGraph2);
        }
    }

    public void SetTiaPanelActive()
    {
        if (!hasAlreadySpokenToTia)
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("receive donut", Function2);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.BindExternalFunction("end tia intro dialogue", TiaIntroDialogueEnd);
            dialogBehaviour.StartDialog(dialogGraph);
        }
        else
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.StartDialog(dialogGraph2);
        }
    }

    public void SetNPCPanelActive()
    {
        if (!hasAlreadySpokenToNPC)
        {
            dialoguePrefab.SetActive(true);
            dialogBehaviour.BindExternalFunction("function", Function);
            dialogBehaviour.BindExternalFunction("end NPC intro dialogue", NPCIntroDialogueEnd);
            dialogBehaviour.StartDialog(dialogGraph);
        }
        else
        {
            bool canGiveClover = PlayerPrefs.GetInt("HasClover", 0) == 1;
            if (canGiveClover)
            {
                dialoguePrefab.SetActive(true);
                dialogBehaviour.BindExternalFunction("Test", DebugExternal);
                dialogBehaviour.BindExternalFunction("give clover", Function);
                dialogBehaviour.StartDialog(dialogGraph3);
            }
            else
            {
                dialoguePrefab.SetActive(true);
                dialogBehaviour.BindExternalFunction("Test", DebugExternal);
                dialogBehaviour.StartDialog(dialogGraph4);
            }

            //dialoguePrefab.SetActive(true);
            //dialogBehaviour.BindExternalFunction("Test", DebugExternal);
            //dialogBehaviour.StartDialog(dialogGraph2);
        }
    }



    private void Function()
    {
        events.Invoke();
    }
    private void Function2()
    {
        events2.Invoke();
    }

    public void MackIntroDialogueEnd()
    {
        hasAlreadySpokenToMack = true;
        // Save the value of hasAlreadySpoken to PlayerPrefs
        PlayerPrefs.SetInt("HasAlreadySpokenToMack", 1);
    }
    public void TiaIntroDialogueEnd()
    {
        hasAlreadySpokenToTia = true;
        // Save the value of hasAlreadySpoken to PlayerPrefs
        PlayerPrefs.SetInt("HasAlreadySpokenToTia", 1);
    }

    public void NPCIntroDialogueEnd()
    {
        hasAlreadySpokenToNPC = true;
        // Save the value of hasAlreadySpoken to PlayerPrefs
        PlayerPrefs.SetInt("HasAlreadySpokenToNPC", 1);
    }
    private void DebugExternal()
    {
        Debug.Log("External function works!");
    }
}