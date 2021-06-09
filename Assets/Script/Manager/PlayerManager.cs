using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Freeze_dead;
    private int MovdeMode=0;
    private static float PlayerSpeed = 1.5f;
    private bool isMove;

    public static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (null == _instance)
            {
                //게임 인스턴스가 없다면 하나 생성해서 넣어준다.
                _instance = new PlayerManager();
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

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            return;
        }

        Player.transform.Translate(Vector3.right * Time.deltaTime);
        //movePlayer();
    }

    public void GameEnd()
    {
        setPlayerMove(true);
        Freeze_dead.SetActive(true);
        SoundManager.Instance.DeadPlay();
        //SceneManager.LoadScene("CodingWarrior");
    }

    public void setPlayerMove(bool onoff)
    {
        isMove = onoff;
    }

    private void movePlayer()
    {
        switch (MovdeMode)
        {
            case 1:
                {
                    Player.transform.position += new Vector3(0, PlayerSpeed*Time.deltaTime);
                    Player.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                }
            case 2:
                {
                    Player.transform.position -= new Vector3(0, PlayerSpeed * Time.deltaTime);
                    Player.transform.eulerAngles = new Vector3(0, 0, -90);
                    break;
                }
            case 3:
                {
                    Player.transform.position -= new Vector3(PlayerSpeed * Time.deltaTime, 0);
                    Player.transform.eulerAngles = new Vector3(180, 0, 180);
                    break;
                }
            case 4:
                {
                    Player.transform.position += new Vector3(PlayerSpeed * Time.deltaTime, 0);
                    Player.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void MoveFunc(int mode)
    {
        //this.MovdeMode = mode;

        switch (mode)
        {
            case 1:
                {
                    //Player.transform.position += new Vector3(0, PlayerSpeed * Time.deltaTime);
                    Player.transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                }
            case 2:
                {
                    //Player.transform.position -= new Vector3(0, PlayerSpeed * Time.deltaTime);
                    Player.transform.eulerAngles = new Vector3(0, 0, -90);
                    break;
                }
            case 3:
                {
                    //Player.transform.position -= new Vector3(PlayerSpeed * Time.deltaTime, 0);
                    Player.transform.eulerAngles = new Vector3(180, 0, 180);
                    break;
                }
            case 4:
                {
                    //Player.transform.position += new Vector3(PlayerSpeed * Time.deltaTime, 0);
                    Player.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
