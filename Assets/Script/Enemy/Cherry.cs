using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public GameObject player;
    public MoveGame moveGame;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("cherryend", 3f);
    }

    private void cherryend()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("맞음");
            GetComponent<AudioSource>().Play();
            moveGame.EndGame();
        }
    }
}
