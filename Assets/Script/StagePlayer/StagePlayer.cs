using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePlayer : MonoBehaviour
{
    private bool isStart;
    private bool isJump;
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
        isJump=false;
    }
    // Start is called before the first frame update
    public void Jump ()
    {
        if(!isStart)
        {
            isStart=true;
            StartCoroutine(waitUndead());
        }

        if(isJump)
        {
            return;
        }

        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 5f,  ForceMode2D.Impulse);
        GetComponent<AudioSource>().Play();
        isJump=true;
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
