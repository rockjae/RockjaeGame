using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1 : MonoBehaviour
{  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != PlayerManager.Instance.Player)
        {
            return;
        }
        
        string[] enemySentence = new string[1];
        switch(Random.Range(0, 5))
        {
            case 0:
                {
                    enemySentence[0] = "printf(\"hello world?\")";
                    break;
                }
            case 1:
                {
                    enemySentence[0] = "printf(\"*****\")";
                    break;
                }
            case 2:
                {
                    enemySentence[0] = "printf(\"하이\")";
                    break;
                }
            case 3:
                {
                    enemySentence[0] = "printf(\"asdf\")";
                    break;
                }
            case 4:
                {
                    enemySentence[0] = "printf(\"test\")";
                    break;
                }
        }
        ConversationManager.Instance.setConversation(enemySentence,this.gameObject,true);
    }
}
