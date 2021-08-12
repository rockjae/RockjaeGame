using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject Pipe_p;

    private void Start()
    {
        Pipe_p.SetActive(false);
    }

    public void pipeGameStart()
    {
        StartCoroutine(PipeInit());
    }

    private IEnumerator PipeInit()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.7f);

            int random = Random.Range(0, 7);

            GameObject tmoOBJ = Instantiate(Pipe_p);
            switch (random)
            {
                case 0:
                    {
                        tmoOBJ.transform.position = new Vector3(3, -2.5f, 0);
                        break;
                    }
                case 1:
                    {
                        tmoOBJ.transform.position = new Vector3(3, -2, 0);
                        break;
                    }
                case 2:
                    {
                        tmoOBJ.transform.position = new Vector3(3, -1, 0);
                        break;
                    }
                case 3:
                    {
                        tmoOBJ.transform.position = new Vector3(3, 0, 0);
                        break;
                    }
                case 4:
                    {
                        tmoOBJ.transform.position = new Vector3(3, 1, 0);
                        break;
                    }
                case 5:
                    {
                        tmoOBJ.transform.position = new Vector3(3, 2, 0);
                        break;
                    }
                case 6:
                    {
                        tmoOBJ.transform.position = new Vector3(3, 2.5f, 0);
                        break;
                    }
            }

            tmoOBJ.SetActive(true);
        }
    }
}
