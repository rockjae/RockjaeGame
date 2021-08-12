using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeJump : MonoBehaviour
{
    public PipeController pipeController;
    public TMP_Text score;

    public AudioClip endClip;

    public GameObject Conversation;
    public TMP_Text Conversation_Text;

    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private bool isStart;
    private bool isEnd;

    private int count;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(rigidbody.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(-100f, 90f, -90f);
        }
        else if(rigidbody.velocity.y == 0)
        {
            transform.eulerAngles = new Vector3(-90f, 90f, -90f);
        }
        else
        {
            transform.eulerAngles = new Vector3(-60f, 90f, -90f);
        }
    }

    public void playerJump()
    {
        if(isEnd)
        { 
            return;
        }

        if(!isStart)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            pipeController.pipeGameStart();
            isStart = true;
        }
        GetComponent<Rigidbody>().AddForce(Vector3.up * 7f, ForceMode.Impulse);

        audioSource.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = endClip;
        audioSource.Play();
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        //Debug.Log("Collision : " + collision.gameObject.name);

        isEnd = true;
        endGame();
    }

    private void OnTriggerEnter(Collider collision)
    {
        count++;
        score.text = count.ToString();
        //Debug.Log("Trigger : " + collision.gameObject.name);
    }

    private void endGame()
    {
        Conversation.SetActive(true);
        Conversation_Text.text = "당신의 점푸 실력 : " + count;

        if (JSONManager.Instance.stageData[3].ClearScore < count)
        {
            JSONManager.Instance.stageData[3].ClearScore = count;
            JSONManager.Instance.SaveDataArray();
        }
    }

    public void returnToTitle()
    {
        SceneManager.LoadScene("firstScene");
    }
}
