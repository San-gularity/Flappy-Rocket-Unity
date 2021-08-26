using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveHighScore(GameOverScreen gameOver)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HighScore.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        ScoreData data = new ScoreData(gameOver);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ScoreData LoadScore()
    {
        string path = Application.persistentDataPath + "/HighScore.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(stream) as ScoreData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Savefile not found" + path);
            return null;
        }
    }

}
