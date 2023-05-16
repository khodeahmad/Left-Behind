using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Generic UI buttons event handlers
/// </summary>
public class EndMenuButtons : MonoBehaviour
{
    [SerializeField] Type type;
    [SerializeField] GameObject FirstButtonSelected;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(FirstButtonSelected);
    }

    public void OnButton()
    {
        if(type == Type.PlayAgain)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        else
        {
            Application.Quit();
        }
    }
    public enum Type { PlayAgain, Quit}
}
