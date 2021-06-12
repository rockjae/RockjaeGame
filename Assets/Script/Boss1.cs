using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public GameObject trueOBJ;
    public GameObject flaseOBJ;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject != PlayerManager.Instance.Player)
        {
            return;
        }
        trueOBJ.SetActive(false);
        flaseOBJ.SetActive(true);
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<BoxCollider2D>().enabled=false;
        SoundManager.Instance.BossPlay();
    }
}
