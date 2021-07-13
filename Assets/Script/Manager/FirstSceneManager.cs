using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    public GameObject JsonManager;
    [Header("StageText")]
    public TMP_Text OpenInfoText;
    public TMP_Text stageText;
    
    [Header("ConverSation")]
    public GameObject converSation;
    public TMP_Text converSation_Text;
    // Start is called before the first frame update
    void Start()
    {
        if(JSONManager.Instance == null)
        {
            Instantiate(JsonManager);
        }
        checkOpenStage();
    }

    private void checkOpenStage()
    {
        //stage2
        if(!JSONManager.Instance.stageData[1].isOpen && JSONManager.Instance.stageData[0].ClearScore > 10)
        {
            JSONManager.Instance.stageData[1].isOpen = true;
            JSONManager.Instance.SaveDataArray();
            converSation.SetActive(true);
            converSation_Text.text = "stage2는 오픈 되어따";
        }
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
        
        int RamdomIndex = Random.Range(0,stageIndex.Count);
        stageText.text = "stage" + (stageIndex[RamdomIndex]+1);
        GetComponent<AudioSource>().Play();

        OpenInfoText.text = JSONManager.Instance.stageData[RamdomIndex].OpenInfo;
    }

    public void startStage()
    {
        SceneManager.LoadScene(stageText.text);
        GetComponent<AudioSource>().Play();
    }
}
