using UnityEngine;
using System.Collections;

public class targetGameStart : MonoBehaviour
{
    public GameObject fpsglock;
    public GameObject Launcher;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // 玩家站到该物体上会触发函数
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 输出游戏开始信息,2秒后继续运行
            GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("击倒三次标靶！");
            Invoke("targetGamePre", 2);
            // 播放音效
            // GetComponent<AudioSource>().Play();
            // 消失
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    // 游戏开始前的准备
    public void targetGamePre()
    {
        fpsglock.SetActive(true);
        Launcher.SetActive(true);
        GameObject.Find("BackMusic").GetComponent<GUITexture>().enabled = true;
        gameObject.SetActive(false);
    }
}
