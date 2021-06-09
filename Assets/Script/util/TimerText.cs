using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timer;

    // Update is called once per frame
    void Update()
    {
        float tmpTime = float.Parse(timer.text) + Time.deltaTime;
        timer.text = tmpTime.ToString();
    }
}
