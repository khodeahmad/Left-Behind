using UnityEngine;
using UnityEngine.UI;

public class ShowLevel : MonoBehaviour
{
    [SerializeField] Text level;
    // Update is called once per frame
    void Update()
    {
        level.text = $"Level : {UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex}";
    }
}
