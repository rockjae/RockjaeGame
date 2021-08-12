using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BinaryGame : MonoBehaviour
{
    public int minNumber = 1;
    public int maxNumber = 100;
    public int targetNumber;
    public TMP_Text ViewText;
    public TMP_Text CountText;
    public TMP_InputField InputField;
    public Button InputBtn;

    [Header("ConverSation")]
    public GameObject Conversation;
    public TMP_Text ConversationText;

    private int count;

    private void Start()
    {
        ViewText.text = minNumber+" to "+ maxNumber;
        targetNumber = Random.Range(minNumber, maxNumber + 1);
    }

    public void BtnClick()
    {
        count++;
        CountText.text = "시도 : " + count;
        this.GetComponent<AudioSource>().Play();

        if (string.IsNullOrEmpty(InputField.text))
        {
            ViewText.text = "입력을 하세요";
        }
        else
        {
            int inputNumber = int.Parse(InputField.text);

            if(inputNumber < minNumber || inputNumber > maxNumber)
            {
                ViewText.text = "입력오류!";
                return;
            }

            if(inputNumber == targetNumber)
            {
                ViewText.text = "골든정답!";
                endStage();
            }
            else if(inputNumber > targetNumber)
            {
                ViewText.text = inputNumber + " 보다 작음";
            }
            else if(inputNumber < targetNumber)
            {
                ViewText.text = inputNumber + " 보다 큼";
            }
        }
    }

    public void endStage()
    {
        Conversation.SetActive(true);
        ConversationText.text = "당신의 시도 : " + count;

        if(JSONManager.Instance.stageData[2].ClearScore == 0)
        {
            JSONManager.Instance.stageData[2].ClearScore = count;
            JSONManager.Instance.SaveDataArray();
        }
        else if (JSONManager.Instance.stageData[2].ClearScore > count)
        {
            JSONManager.Instance.stageData[2].ClearScore = count;
            JSONManager.Instance.SaveDataArray();
        }
    }

    public void returnToTitle()
    {
        SceneManager.LoadScene("firstScene");
    }
}
