using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] public int thisIndex;
    [SerializeField] Type type;

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
                switch (type)
                {
                    case Type.StartGame:
                        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                        break;
                    case Type.Quit:
                        Application.Quit();
                        break;
                    case Type.Continue:
                        var level = StartMenu.LoadLevel();
                        SceneManager.LoadScene(level.currentLevel);
                        break;
                    default:
                        break;
                }
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public enum Type { StartGame, Quit, Continue }
}
