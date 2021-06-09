using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationMonster : MonoBehaviour
{
    [SerializeField]
    private string[] text;
    [SerializeField]
    private bool isDestroy;
    [SerializeField]
    private bool isGameOver;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != PlayerManager.Instance.Player)
        {
            return;
        }

        ConversationManager.Instance.setConversation(text, this.gameObject, isDestroy, isGameOver);
    }
}
