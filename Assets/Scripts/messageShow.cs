using UnityEngine;
using System.Collections;

public class messageShow : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // 使用GUIText接收到消息将其字体在1秒内由小到大打印然后两秒后消失
    public void ShowMessage(string message)
    {
        GetComponent<GUIText>().fontSize = 27;
        GetComponent<GUIText>().text = message;
        // GetComponent<GUIText>().enabled = true;
        Invoke("FontSize", 0.8f);
        Invoke("FontSize", 0.8f);
        Invoke("HideMessage", 2);
    }
    // 字体大小变化
    void FontSize()
    {
        GetComponent<GUIText>().fontSize += 10;
    }
    // 消息消失
    void HideMessage()
    {
        GetComponent<GUIText>().text = "";
        // GetComponent<GUIText>().enabled = false;
    }

}
