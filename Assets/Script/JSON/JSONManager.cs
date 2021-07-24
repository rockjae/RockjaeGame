using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public static class CollectionExtensions
     {
         public static List<T> ToList<T> (this T[] array)
         {
             List<T> output = new List<T>();
             output.AddRange(array);
             return output;
         }
     }

public class JSONManager : MonoBehaviour
{ 
    
    private static JSONManager _instance = null;
    public static JSONManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<JSONManager>();
            }

            return _instance;
        }
    }

    public List<StageData> stageData;

    public delegate void FileLoad();
    public FileLoad fileLoad;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadDataArray();
    }

    public void SaveDataArray()
    {
        StageDataArray stageDataList = new StageDataArray();
        stageDataList.m_stageDataArray = stageData.ToArray();
        string jsonData = JsonConvert.SerializeObject(stageDataList);
        CreateJsonFile(jsonData);
    }

    public void LoadDataArray()
    {
        StageDataArray stageDataList = new StageDataArray();
        stageDataList = LoadJsonFile<StageDataArray>();
        stageData = CollectionExtensions.ToList<StageData>(stageDataList.m_stageDataArray);
        
        if(stageData.Count < NamingString.StageName.Length)
        {
            Debug.Log("update stageData");

            int tmpCount = NamingString.StageName.Length - stageData.Count;
            
            Debug.Log("tmpCount : " +tmpCount);
            for(int i = 0 ; i < tmpCount ; i++)
            {
                stageData.Add(new StageData());
            }
            SaveDataArray();
        }

        fileLoad(); //delegate 호출
    }

    private string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    private T JsonToOject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
    
    private void CreateJsonFile(string jsonData)
    {
        string createPath = "";
        #if UNITY_EDITOR
                createPath = Application.dataPath;
        #elif UNITY_ANDROID || UNITY_IOS
                createPath = Application.persistentDataPath;
        #endif

        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, "StageInfoJSON"), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    private T LoadJsonFile<T>()
    {
        string loadPath = "";
        #if UNITY_EDITOR
                loadPath = Application.dataPath;
        #elif UNITY_ANDROID || UNITY_IOS
                loadPath = Application.persistentDataPath;
        #endif

        Debug.Log("loadPath : " + loadPath);
        FileInfo fileinfo = new FileInfo(loadPath+"/StageInfoJSON.json");
        if(fileinfo.Exists)
        {
            Debug.Log("Exists");
            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, "StageInfoJSON"), FileMode.Open);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            string jsonData = Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
        else
        {
            Debug.Log("not Exists");
            SaveDataArray();

            FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, "StageInfoJSON"), FileMode.Open);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            string jsonData = Encoding.UTF8.GetString(data);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }
    }
}
