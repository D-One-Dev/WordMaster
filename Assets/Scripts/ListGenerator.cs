using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ListGenerator : MonoBehaviour
{
    public List<string> wordsList = new List<string>();
    void Start()
    {
        string dbPath = "";
        if (Application.platform == RuntimePlatform.Android)
        {
            string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "List.txt");
            WWW reader = new WWW(oriPath);
            while(!reader.isDone){}
            string realPath = Application.persistentDataPath + "/db";
            System.IO.File.WriteAllBytes(realPath, reader.bytes);
            dbPath = realPath;
        }
        else
        {
            dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, "List.txt");
        }
        using (StreamReader sr = new StreamReader(dbPath, Encoding.Default))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                wordsList.Add(line);
            }
        }
    }
}