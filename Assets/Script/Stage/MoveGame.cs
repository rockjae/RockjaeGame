using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoveGame : MonoBehaviour
{
    public TMP_Text TimerText;
    public GameObject Cherry;
    private float timer;
    private bool isEnd;
    [Header("conversation")]
    public GameObject Conversation;
    public TMP_Text converSation;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zenCherry());
    }

    IEnumerator zenCherry()
    {
        while (true)
        {
            GameObject tmpOBJ = Instantiate(Cherry);
            int random = Random.Range(0, 6);
            tmpOBJ.transform.position = new Vector3(-2.5f + random, 5.52f, 0);
            tmpOBJ.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
    }

    private void Update()
    {
        if(isEnd)
        {
            return;
        }
        timer += Time.deltaTime;
        TimerText.text = timer.ToString();
    }

    public void EndGame()
    {
        if(!isEnd)
        {
            isEnd = true;
        }
        else
        {
            return;
        }

        Conversation.SetActive(true);
        converSation.text = "당신의 이동 실력 : " + TimerText.text + "초";

        if (JSONManager.Instance.stageData[1].ClearTime < float.Parse(TimerText.text))
        {
            JSONManager.Instance.stageData[1].ClearTime = float.Parse(TimerText.text);
            JSONManager.Instance.SaveDataArray();
        }
    }

    public void returnToTitle()
    {
        SceneManager.LoadScene("firstScene");
    }
}
