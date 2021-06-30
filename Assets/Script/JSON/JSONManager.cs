using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class JSONManager : MonoBehaviour
{ 
    public string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public T JsonToOject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
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
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, "StageInfoJSON"), FileMode.Create);
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

        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, "StageInfoJSON"), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
    void Start()
    {
        /*
        StageData stageData = new StageData();
        string jsonData = ObjectToJson(stageData);
        Debug.Log(jsonData);
        CreateJsonFile(jsonData);
        */
        

        GameObject obj = new GameObject();
        obj.name = "StageInfo 01";

        var stageinfo = obj.AddComponent<StageInfoJSON>();
        stageinfo.stageData = LoadJsonFile<StageData>();

        var jsonData = JsonUtility.ToJson(stageinfo.stageData);
        Debug.Log("stageinfo : "+ stageinfo.stageData);
        Debug.Log("jsonData : "+ jsonData);

        JsonUtility.FromJsonOverwrite(jsonData, stageinfo);
        
        
/*
        GameObject obj2 = new GameObject();
        obj2.name = "StageInfo 02";
        var t2 = obj2.AddComponent<StageInfo>();
        JsonUtility.FromJsonOverwrite(jd, t2);
        */
    }
}
