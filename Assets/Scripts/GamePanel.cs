using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GamePanel : MonoBehaviour
{
    // Start is called before the first frame update
    private bool IsPause = false;
    [SerializeField] GameObject ResumeButton;
    [SerializeField] GameObject ExitButton;
    [SerializeField] GameObject StartAgainButton;
    [SerializeField] GameObject BackGround;

    void Start()
    {
        ResumeButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        StartAgainButton.gameObject.SetActive(false);
        BackGround.gameObject.SetActive(false);
        Cursor.visible = false;


        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(ResumeButton);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            if (IsPause)
            {
                ResumeButton.gameObject.SetActive(false);
                ExitButton.gameObject.SetActive(false);
                StartAgainButton.gameObject.SetActive(false);
                BackGround.gameObject.SetActive(false);
                IsPause = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
            else
            {
                ResumeButton.gameObject.SetActive(true);
                StartAgainButton.gameObject.SetActive(true);
                ExitButton.gameObject.SetActive(true);
                BackGround.gameObject.SetActive(true);
                IsPause = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
                EventSystem.current.SetSelectedGameObject(null);
                //set a new selected object
                EventSystem.current.SetSelectedGameObject(ResumeButton);
            }
        }
        
    }

    public void ClickToResume()
    {
        ResumeButton.gameObject.SetActive(false);
        StartAgainButton.gameObject.SetActive(false);
        ExitButton.gameObject.SetActive(false);
        BackGround.gameObject.SetActive(false);
        IsPause = false;
        Time.timeScale = 1f;
    }

    public void ClickToExit()
    {
        Application.Quit();
    }

    public void ClickToStartAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        IsPause = false;
        Time.timeScale = 1f;
    }
}
