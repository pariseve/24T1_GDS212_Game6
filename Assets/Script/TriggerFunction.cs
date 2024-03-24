using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TriggerFunction : MonoBehaviour
{
    [SerializeField] private UnityEvent Function;
    public TextMeshProUGUI text;

    private bool isTextVisible = false;
    private bool hasInteracted = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D called"); // Add this line to check if the method is being called

        if (collision.CompareTag("Player"))
        {

            text.gameObject.SetActive(true);
            isTextVisible = true;
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("E key pressed"); // Add this line to check if the "E" key is being detected

                // Invoke the function and hide the text
                Function.Invoke();
                //if (text != null)
                //{
                //    // Hide the text and update the flag when the player exits the trigger area
                //    text.gameObject.SetActive(false);
                //    isTextVisible = false;
                //}
            }
        }

      
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if the text object is not null before accessing it
            if (text != null)
            {
                // Hide the text and update the flag when the player exits the trigger area
                text.gameObject.SetActive(false);
                isTextVisible = false;
            }
        }
    }

}
