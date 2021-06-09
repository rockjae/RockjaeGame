using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Normal;
    [SerializeField]
    private AudioClip Dead;

public static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (null == _instance)
            {
                //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
                _instance = new SoundManager();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        //DontDestroyOnLoad(gameObject);
    }

    public void DeadPlay()
    {
        audioSource.clip = Dead;
        audioSource.Play();
    }

    public void NormalPlay()
    {
        audioSource.clip = Normal;
        audioSource.Play();
    }
}
