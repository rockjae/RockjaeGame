using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveGame : MonoBehaviour
{
    public TMP_Text TimerText;
    public GameObject Cherry;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zenCherry());
    }

    IEnumerator zenCherry()
    {
        while (true)
        {
            GameObject tmpOBJ = Instantiate(Cherry);
            int random = Random.Range(0, 6);
            tmpOBJ.transform.position = new Vector3(-2.5f + random, 5.52f, 0);
            tmpOBJ.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        TimerText.text = ((int)timer).ToString()+"초";
    }
}
