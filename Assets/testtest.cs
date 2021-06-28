using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = new GameObject();
        var t = obj.AddComponent<StageJSON>();
        t.LoadJsonFile<StageInfo>();
        var jd = JsonUtility.ToJson(obj.GetComponent<StageJSON>());
        Debug.Log(jd);
    }

}
