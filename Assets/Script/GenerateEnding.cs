using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;
using UnityEngine.SceneManagement;

public class GenerateEnding : MonoBehaviour
{

    [SerializeField] private DialogBehaviour dialogBehaviour;
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    public void MackEnding()
    {
        SceneManager.LoadScene("MackEnding");
    }

    public void TiaEnding()
    {
        SceneManager.LoadScene("TiaEnding");
    }

    
}
