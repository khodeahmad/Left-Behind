using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public static void SaveLevel(LevelData levelSave)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levelsave.un";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(levelSave);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadLevel()
    {
        string path = Application.persistentDataPath + "/levelsave.un";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        }
        else
        {
            return new LevelData(1);
        }
    }

    public static bool IsLevelDataEmpty()
    {
        string path = Application.persistentDataPath + "/levelsave.un";
        return !File.Exists(path);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        var level = LoadLevel();
        SceneManager.LoadScene(level.currentLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
