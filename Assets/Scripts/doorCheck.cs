using UnityEngine;
using System.Collections;

public class doorCheck : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // 触发器，有钥匙则开门，否则不开
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GameObject.Find("haveKey").GetComponent<keyGet>().keyNum == 3)
            {
                // 父物体播放开门动画
                transform.parent.GetComponent<Animation>().Play();
                // 播放音效
                GetComponent<AudioSource>().Play();
                // 发送消息
                // GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("暂时安全了，但与此同时…");
                GameObject.Find("haveFlash").GetComponent<GUITexture>().enabled = false;
                GameObject.Find("haveKey").GetComponent<GUITexture>().enabled = false;
                GameObject.Find("FlashLight").GetComponent<Light>().enabled = false;
                GameObject.Find("haveKey").GetComponent<GUIText>().text = "";
                // 调用预制体winGUI
                GameObject.Find("winGUI").GetComponent<winGame>().SendMessage("GameOver");

            }
            else if (GameObject.Find("haveKey").GetComponent<keyGet>().keyNum > 0)
            {
                GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("还需要" + (3 - GameObject.Find("haveKey").GetComponent<keyGet>().keyNum).ToString() + "个钥匙碎片");
            }
            else
            {
                GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("门被锁住了，好像需要钥匙");
            }
        }
    }
}
