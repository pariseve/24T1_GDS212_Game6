using cherrydev;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.PackageManager;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroDialogue : MonoBehaviour
{
    public GameObject dialoguePrefab_;

    [SerializeField] private string sceneName;
    [SerializeField] private string sceneName2;

    [SerializeField] private DialogBehaviour dialogBehaviour_;
    [SerializeField] private DialogNodeGraph dialogGraph_;
    [SerializeField] private UnityEvent events;

    private bool hasFinishedIntro = false;

    private void Start()
    {
        hasFinishedIntro = PlayerPrefs.GetInt("hasFinishedIntro", 0) == 1;
        string currentSceneName = SceneManager.GetActiveScene().name;
        string firstSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == sceneName)
        {
            DisplayDialogue();
        }
        else if (firstSceneName == sceneName2)
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
            dialogBehaviour_.BindExternalFunction("function", Function);
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
