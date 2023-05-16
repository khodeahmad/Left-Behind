using UnityEngine;
using UnityEngine.UI;

public class FirstTimeRunning : MonoBehaviour
{
    [SerializeField] GameObject ContinueButton;
    [SerializeField] MenuButton StartButton;
    [SerializeField] MenuButton QuitButton;
    [SerializeField] Type type;

    private void Awake()
    {
        switch (type)
        {
            case Type.StartMenu:
                if (StartMenu.IsLevelDataEmpty())
                {
                    ContinueButton.GetComponent<MenuButton>().enabled = false;
                    ContinueButton.GetComponent<Button>().enabled = false;
                    ContinueButton.GetComponentInChildren<Text>().color = Color.grey;
                    StartButton.thisIndex = 0;
                    QuitButton.thisIndex = 1;
                    MenuButtonController.maxIndex = 1;
                }
                else
                {
                    MenuButtonController.maxIndex = 2;
                }
                break;
            case Type.EndMenu:
                StartButton.thisIndex = 0;
                QuitButton.thisIndex = 1;
                MenuButtonController.maxIndex = 2;
                break;
            default:
                break;
        }
    }

    public enum Type { StartMenu,EndMenu }
}
