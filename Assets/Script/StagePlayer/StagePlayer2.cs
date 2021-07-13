using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePlayer2 : MonoBehaviour
{
    private bool isStart;
    private int isTurn=1;
    public GameObject unDead1;
    public AudioClip deadSound;
    public GameObject GameOverText;
    public TMP_Text score;
    public TMP_Text converSation;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == unDead1)
        {
            Destroy(unDead1);
            GetComponent<AudioSource>().clip=deadSound;
            GetComponent<AudioSource>().Play();

            GameOverText.SetActive(true);
            converSation.text = "당신의 점푸 실력 : " + score.text;

            if(JSONManager.Instance.stageData[0].ClearScore < int.Parse(score.text))
            {
                JSONManager.Instance.stageData[0].ClearScore = int.Parse(score.text);
                JSONManager.Instance.SaveDataArray();
            }
        }
    }

    void Update()
    {
        transform.position += new Vector3(isTurn*Time.deltaTime,0,0);
    }

    // Start is called before the first frame update
    public void Turn ()
    {
        if(isTurn == 1)
        {
            isTurn = -1;
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else
        {
            isTurn = 1;
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }


    IEnumerator waitUndead()
    {
        yield return new WaitForSeconds(1f);
        unDead1.SetActive(true);
    }

    public void returnToTitle()
    {
        SceneManager.LoadScene("firstScene");
    }
}
