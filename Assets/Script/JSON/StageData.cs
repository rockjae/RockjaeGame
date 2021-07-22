using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StageDataArray
{    
    public StageData[] m_stageDataArray;
}

[Serializable]
public class StageData
{
    public bool isOpen;
    public int ClearScore;
    public int ClearCount;
    public float ClearTime;    
    public string etc;
}
