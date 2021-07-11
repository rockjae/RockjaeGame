using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    public TMP_Text stageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void seletStage()
    {
        List<int> stageIndex = new List<int>();
        foreach(var stage in JSONManager.Instance.stageData.Select((value, index)=>(value, index)))
        {
            if(stage.value.isOpen)
            {
                stageIndex.Add(stage.index);
            }
        }
        
        stageText.text = "stage" + (stageIndex[Random.Range(0,stageIndex.Count)]+1);
        GetComponent<AudioSource>().Play();
    }

    public void startStage()
    {
        SceneManager.LoadScene(stageText.text);
        GetComponent<AudioSource>().Play();
    }
}
