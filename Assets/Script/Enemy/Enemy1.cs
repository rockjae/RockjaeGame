using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    //IEnumerator _waitSound;
    public GameObject BoxControl;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != PlayerManager.Instance.Player)
        {
            return;
        }

        if (BoxControl.transform.childCount != 0)
        {
            string[] defaultSentence = new string[1];
            defaultSentence[0] = "넌 누구니?";
            ConversationManager.Instance.setConversation(defaultSentence, this.gameObject, false);
            return;
        }

        string[] enemySentence = new string[3];
        enemySentence[0] = "hello world?";
        enemySentence[1] = "안녕 난 printf 야";
        enemySentence[2] = "문자를 출력하는 거 밖에 못하지만 모든것을 할 수 있는 기분이야";
        ConversationManager.Instance.setConversation(enemySentence,this.gameObject, true);
        //Vector3 tmp = PlayerManager.Instance.Player.transform.position - this.transform.position;
        //PlayerManager.Instance.Player.transform.position += new Vector3(tmp.x/5f, tmp.y/5f, 0);
        /*
        if(_waitSound == null)
        {
            GetComponent<AudioSource>().Play();
            _waitSound = waitSound();
            StartCoroutine(_waitSound);
        }
        */
    }

    IEnumerator waitSound()
    {
        while (true)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                break;
            }
            yield return null;
        }
        //StageManager.Instance.MakeStage(2);
    }
}
