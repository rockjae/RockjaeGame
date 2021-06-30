using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMonoExample : JSONManager
{
    private StageInfoJSON stageInfo;
    // Start is called before the first frame update
    void Start()
    {
        StageInfoJSON stgInfo = new StageInfoJSON();
        string jsonData = ObjectToJson(stgInfo);
        Debug.Log(jsonData);
        CreateJsonFile(jsonData);

/*
        stageInfo = LoadJsonFile<StageInfoJSON>();

        GameObject obj = new GameObject();
        obj.name = "StageInfo 01";
        var t = obj.AddComponent<StageInfoJSON>();
        var jd = JsonUtility.ToJson(stageInfo);
        JsonUtility.FromJsonOverwrite(jd, t);
        Debug.Log(jd);
        */
/*
        GameObject obj2 = new GameObject();
        obj2.name = "StageInfo 02";
        var t2 = obj2.AddComponent<StageInfo>();
        JsonUtility.FromJsonOverwrite(jd, t2);
        */
    }
}
