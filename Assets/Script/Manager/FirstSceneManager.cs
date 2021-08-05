using System;
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
            JSONManager.Instance.fileLoad += fileLoadEnd;
        }
        else
        {
            checkOpenStage();
            seletStage();
        }
    }

    void fileLoadEnd()
    {
        seletStage();
    }

    private void checkOpenStage()
    {
        //stage2 open
        if(!JSONManager.Instance.stageData[1].isOpen && JSONManager.Instance.stageData[0].ClearScore > 10)
        {
            JSONManager.Instance.stageData[1].isOpen = true;
            JSONManager.Instance.SaveDataArray();
            converSation.SetActive(true);
            converSation_Text.text = GetCompleteWorld(converSation_Text.text = NamingString.StageName[1], "은", "는") + " 오픈 되어따";
        }

        //stage3 open
        if (!JSONManager.Instance.stageData[2].isOpen && JSONManager.Instance.stageData[1].ClearTime > 10f)
        {
            JSONManager.Instance.stageData[2].isOpen = true;
            JSONManager.Instance.SaveDataArray();
            converSation.SetActive(true);
            converSation_Text.text = GetCompleteWorld(converSation_Text.text = NamingString.StageName[2], "은", "는") + " 오픈 되어따";
        }

        //stage4 open
        if (!JSONManager.Instance.stageData[3].isOpen && JSONManager.Instance.stageData[2].ClearScore > 1)
        {
            JSONManager.Instance.stageData[3].isOpen = true;
            JSONManager.Instance.SaveDataArray();
            converSation.SetActive(true);
            converSation_Text.text = GetCompleteWorld(converSation_Text.text = NamingString.StageName[3],"은","는") + " 오픈 되어따";
        }
    }

    public string GetCompleteWorld(string name, string firstVal, string secondVal)
    {
        char lastName = name.ElementAt(name.Length - 1);
        int index = (lastName - 0xAC00) % 28;
        Console.WriteLine(index);
        //한글의 제일 처음과 끝의 범위 밖일경우 에러 
        if (lastName < 0xAC00 || lastName > 0xD7A3)
        {
            return name;
        }

        string selectVal = (lastName - 0xAC00) % 28 > 0 ? firstVal : secondVal;

        return name + selectVal;
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
        
        int RamdomIndex = UnityEngine.Random.Range(0,stageIndex.Count);
        //stageText.text = "stage" + (stageIndex[RamdomIndex]+1);
        stageText.text = NamingString.StageName[RamdomIndex];
        GetComponent<AudioSource>().Play();

        OpenInfoText.text = SetStageInfoText(RamdomIndex);
    }

    private string SetStageInfoText(int Index)
    {
        string _clearScore ="";
        string _clearCount ="";
        string _clearTime ="";
        string _Etc ="";
        
        _clearScore = JSONManager.Instance.stageData[Index].ClearScore != 0 ? "점수 : "+JSONManager.Instance.stageData[Index].ClearScore.ToString() : ""; 
        _clearCount = JSONManager.Instance.stageData[Index].ClearCount != 0 ? "\n클리어 횟수 : "+JSONManager.Instance.stageData[Index].ClearCount.ToString() : "";
        _clearTime = JSONManager.Instance.stageData[Index].ClearTime != 0 ? "\n클리어 시간 : "+JSONManager.Instance.stageData[Index].ClearTime.ToString() : "";
        _Etc = !string.IsNullOrEmpty(JSONManager.Instance.stageData[Index].etc) ? "\netc : "+JSONManager.Instance.stageData[Index].etc.ToString() : "";

        return _clearScore+_clearCount+_clearTime+_Etc;
    }

    public void startStage()
    {
        SceneManager.LoadScene(Array.IndexOf(NamingString.StageName,stageText.text)+1);
        GetComponent<AudioSource>().Play();
    }
}
