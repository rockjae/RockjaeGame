using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

[Serializable]
public class StageInfo
{
    public bool isOpen;
    public int ClearScore;
    public int ClearCount;
    public float ClearTime;

    public StageInfo()
    {
        isOpen=false;
        ClearScore=0;
        ClearCount=0;
        ClearTime=0;
    }
    
    public void Print()
    {
        Debug.Log("isOpen : "+isOpen);
        Debug.Log("ClearScore : "+ClearScore);
        Debug.Log("ClearCount : "+ClearCount);
        Debug.Log("ClearTime : "+ClearTime);
    }
}

public class StageJSON : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        StageInfo stgInfo = new StageInfo();
        string jsonData = JsonUtility.ToJson(stgInfo);
        Debug.Log(jsonData);
        CreateJsonFile(jsonData);
        */
        
        //var jtc2 = LoadJsonFile<StageInfo>();
        //jtc2.Print();
    }

    public void CreateJsonFile(string jsonData)
    {
        string createPath = "";
        #if UNITY_EDITOR
                createPath = Application.dataPath;
        #elif UNITY_ANDROID || UNITY_IOS
                createPath = Application.persistentDataPath;
        #endif

                Debug.Log(createPath);
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, "StageInfo"), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    public T LoadJsonFile<T>()
    {
        string loadPath = "";
        #if UNITY_EDITOR
                loadPath = Application.dataPath;
        #elif UNITY_ANDROID || UNITY_IOS
                loadPath = Application.persistentDataPath;
        #endif

        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, "StageInfo"), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonUtility.FromJson<T>(jsonData);
    }
}
