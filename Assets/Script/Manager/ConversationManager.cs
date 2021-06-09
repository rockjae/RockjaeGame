using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    public GameObject Conversation;
    public TMP_Text ConversationText;

    private string[] _sentence;
    private int _count;
    private GameObject _targetOBJ;
    //private bool _isNextStage;
    private bool _isGameOver;
    private bool _isDestroyOBJ;

    public static ConversationManager _instance;
    public static ConversationManager Instance
    {
        get
        {
            if (null == _instance)
            {
                //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
                _instance = new ConversationManager();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void setConversation(string[] sentence, GameObject targetOBJ, bool isDestroyOBJ, bool isGameOver = false)
    {
        _count = 0;
        if (!Conversation.activeSelf)
        {
            Conversation.SetActive(true);
        }

        PlayerManager.Instance.Player.GetComponent<BoxCollider2D>().enabled = false;
        _sentence = sentence;
        ConversationText.text = _sentence[_count];
        PlayerManager.Instance.setPlayerMove(true);

        if (isDestroyOBJ)
        {
            _targetOBJ = targetOBJ;
            _isDestroyOBJ = isDestroyOBJ;
        }
        else
        {
            Vector3 tmp = PlayerManager.Instance.Player.transform.position - targetOBJ.transform.position;
            PlayerManager.Instance.Player.transform.position += new Vector3(tmp.x/5f, tmp.y/5f, 0);
        }
        //_isNextStage = isNextStage;
        _isGameOver = isGameOver;
    }

    public void nextSentence()
    {
        _count++;
        if (_count < _sentence.Length)
        {
            ConversationText.text = _sentence[_count];
        }
        else
        {
            _count = 0;
            PlayerManager.Instance.Player.GetComponent<BoxCollider2D>().enabled = true;
            Conversation.SetActive(false);
            PlayerManager.Instance.setPlayerMove(false);

            if (_isDestroyOBJ)
            {
                Destroy(_targetOBJ);
                _targetOBJ = null;
                GetComponent<AudioSource>().Play();
                _isDestroyOBJ = false;
            }
/*
            if (_isNextStage)
            {
                StageManager.Instance.MakeNextStage();
                _isNextStage = false;
            }
*/
            if(_isGameOver)
            {
                _isGameOver = false;
                PlayerManager.Instance.GameEnd();
            }
        }
    }
}
