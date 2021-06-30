using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageData
{
    public bool isOpen;
    public int ClearScore;
    public int ClearCount;
    public float ClearTime;

    public StageData()
    {
        isOpen = false;
        ClearScore = 0;
        ClearCount = 0;
        ClearTime = 0;
    }
    
}


public class StageInfoJSON : MonoBehaviour
{
    private static StageInfoJSON _instance = null;
    public static StageInfoJSON Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StageInfoJSON>();
            }

            return _instance;
        }
    }

    public StageData stageData;
}
