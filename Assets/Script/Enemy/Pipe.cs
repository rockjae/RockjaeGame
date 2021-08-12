using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        transform.position -= new Vector3(3f*Time.deltaTime, 0, 0);

        if(timer > 5f)
        {
            Destroy(this.gameObject);
        }
    }
}
