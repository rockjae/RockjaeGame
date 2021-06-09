using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    // Start is called before the first frame update
    private const float speed = 3;
    void Start()
    {
        StartCoroutine(ranMove());
    }

    IEnumerator ranMove()
    {
        int ran = Random.Range(0,4);
        float timer = 0;

        while(true)
        {
            timer += Time.deltaTime;
            switch(ran)
            {
                case 0:
                {
                    this.transform.localPosition += new Vector3(speed*this.transform.localPosition.x*Time.deltaTime,0,0);
                    break;
                }
                case 1:
                {
                    this.transform.localPosition -= new Vector3(speed*this.transform.localPosition.x*Time.deltaTime,0,0);
                    break;
                }
                case 2:
                {
                    this.transform.localPosition += new Vector3(0,speed*this.transform.localPosition.y*Time.deltaTime,0);
                    break;
                }
                case 3:
                {
                    this.transform.localPosition -= new Vector3(0,speed*this.transform.localPosition.y*Time.deltaTime,0);
                    break;
                }
            }

            if(timer > 0.1f)
            {
                timer = 0;
                ran = Random.Range(0,4);
            }
            yield return null;
        }
    }
}
