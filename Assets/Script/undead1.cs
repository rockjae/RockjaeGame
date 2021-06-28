using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class undead1 : MonoBehaviour
{
    public TMP_Text score;
    public int count;
    // Start is called before the first frame update
    public void countUndead()
    {
        count++;
        score.text = count.ToString();
    }
}
