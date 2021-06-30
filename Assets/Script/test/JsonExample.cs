using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Text;

[System.Serializable]
public class UJsonTester
{
    public Vector3 v3;

    public UJsonTester() { }

    public UJsonTester(float f)
    {
        v3 = new Vector3(f, f, f);
    }

    public UJsonTester(Vector3 v)
    {
        v3 = v;
    }
}

public class JsonExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        JTestClass jtc = new JTestClass(true);
        string jsonData = ObjectToJson(jtc);
        Debug.Log(jsonData);

        var jtc2 = JsonToOject<JTestClass>(jsonData);
        jtc2.Print();
        */

        /*
        JTestClass jtc = new JTestClass(true);
        string jsonData = ObjectToJson(jtc);
        CreateJsonFile(Application.dataPath, "JTestClass", jsonData);

        var jtc2 = LoadJsonFile<JTestClass>(Application.dataPath, "JTestClass");
        jtc2.Print();
        */
        /*
        UJsonTester jt = new UJsonTester(transform.position);
        Debug.Log(JsonUtility.ToJson(jt));
        */
    }

    string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    T JsonToOject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }

    void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    T LoadJsonFile<T>(string loadPath, string fileName)
    {
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}

// BackGroundData.Instance.userData = JsonConvert.DeserializeObject<UserData>(responseData.ToString());

/*
[Serializable]
public class UserData
{
    public int uuid;
    public string name;
    public string firstName;
    public string lastName;
    public string profile;
    public string department;
    public string createDate;
    public string updateDate;
}


public class BackGroundData : MonoBehaviour
{
    private static BackGroundData _instance = null;
    public static BackGroundData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BackGroundData>();
            }

            return _instance;
        }
    }
    public UserData userData;
}

*/