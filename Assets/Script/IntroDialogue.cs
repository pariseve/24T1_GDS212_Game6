using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{
    public GameObject dialoguePrefab_;

    [SerializeField] private DialogBehaviour dialogBehaviour_;
    [SerializeField] private DialogNodeGraph dialogGraph_;
    [SerializeField] private UnityEvent events;

    private bool hasFinishedIntro = false;

    private void Start()
    {
        hasFinishedIntro = PlayerPrefs.GetInt("hasFinishedIntro", 0) == 1;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {

            DisplayDialogue();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneDialogue();
        }
    }
    public void DisplayDialogue()
    {
        dialoguePrefab_.SetActive(true);
        dialogBehaviour_.BindExternalFunction("Test", DebugExternal);
        dialogBehaviour_.BindExternalFunction("function", Function);
        dialogBehaviour_.BindExternalFunction("finish intro", EndIntroDialogue);
        dialogBehaviour_.StartDialog(dialogGraph_);

    }

    public void SceneDialogue()
    {
        if (hasFinishedIntro == false)
        {

            dialoguePrefab_.SetActive(true);
            dialogBehaviour_.BindExternalFunction("Test", DebugExternal);
            dialogBehaviour_.BindExternalFunction("finish intro", EndIntroDialogue);
            dialogBehaviour_.StartDialog(dialogGraph_);
            hasFinishedIntro = true;
        }
        //else
        //{
        //    dialoguePrefab_.SetActive(false);
        //}
    }
    private void Function()
    {
        events.Invoke();
    }

    public void EndIntroDialogue()
    {
        hasFinishedIntro = true;

        PlayerPrefs.SetInt("hasFinishedIntro", 1);
    }

    private void DebugExternal()
    {
        Debug.Log("External function works!");
    }
}
