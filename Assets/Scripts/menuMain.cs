using UnityEngine;
using System;
using System.Collections;
using System.Threading;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
public class menuMain : MonoBehaviour
{

    public string startGame;
    public Texture2D normalTexture;
    public Texture2D rollOverTexture;
    public AudioClip beep;
    public bool quitGame = false;
    public bool instruction = false;
    public bool updateGame = false;
    public GUIText textTitle;
    public GUIText textContent;
    public GUIText textHints;
    public string UrlResponse;// 游戏更新网页返回内容
    public string urlVersion;
    public string urlContent;
    public Version gameVersion;
    public GameObject subMenu;
    void Start()
    {
        // 将menu_version中的版本号赋值给gameVersion
        gameVersion = new Version(GameObject.Find("menu_version").guiText.text.Split('：')[1]);
    }
    void OnMouseEnter()
    {
        guiTexture.texture = rollOverTexture;
    }
    void OnMouseExit()
    {
        guiTexture.texture = normalTexture;
    }
    IEnumerator OnMouseUp()
    {
        audio.PlayOneShot(beep);
        if (quitGame)
        {
            Application.Quit();
        }
        else if (instruction)
        {
            subMenu.SetActive(true);
            string instruction_title = "游戏说明";
            textTitle.guiText.text = instruction_title;
            string raw_instruction_content = "本游戏是一款密室解谜游戏，基于Unity4.6.8制作。";
            string instruction_content = "";
            for (int i = 0; i < raw_instruction_content.Length; i++)
            {
                instruction_content += raw_instruction_content[i];
                if ((i + 1) % 14 == 0)
                {
                    instruction_content += "\n";
                }
            }
            textContent.guiText.text = instruction_content;
        }
        else if (updateGame)
        {

            subMenu.SetActive(true);
            UrlThread();
            string[] parts = UrlResponse.Split('\n');
            urlVersion = parts[0];
            urlContent = parts[1];
            Version newVersion = new Version(urlVersion);
            string newContent = "";
            // 每20个字符添加一个换行符
            for (int i = 0; i < urlContent.Length; i++)
            {
                newContent += urlContent[i];
                if ((i + 1) % 14 == 0)
                {
                    newContent += "\n";
                }
            }
            textTitle.guiText.text = "更新游戏";
            if (gameVersion < newVersion)
            {
                textContent.guiText.text = "新版本号：" + newVersion.ToString() + "\n更新内容：\n" + newContent + "\n请前往官网进行更新。";
            }
            else
            {
                textContent.guiText.text = "当前版本：" + gameVersion.ToString() + "\n已是最新版本。";
            }

            // textHints.SendMessage("ShowHint", urlVersion + "分隔" + urlContent);
            // Debug.Log("Version: " + PlayerSettings.bundleVersion);
        }
        else
        {
            Application.LoadLevel(startGame);
        }
		yield return new WaitForSeconds(0.35f);
    }

    // public void UpdateGame()
    // {
    //     GetUrlThread = new Thread(UrlThread);
    //     GetUrlThread.Start();
    //     Invoke("GetHtmlStr", 0.5f);
    // }
    public void UrlThread()
    {
        WebRequest request = WebRequest.Create("http://i2358230d7.yicp.fun:50320/get_b");
        WebResponse response = request.GetResponse();
        Stream dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseFromServer = reader.ReadToEnd();
        UrlResponse = responseFromServer;
        reader.Close();
        response.Close();
    }

    // public void GetHtmlStr()
    // {
    //     string url = "https://netcut.cn/%E8%A7%A3%E8%B0%9C%E6%B8%B8%E6%88%8F";
    //     if (Application.internetReachability == NetworkReachability.NotReachable)
    //     {
    //         textHints.SendMessage("ShowHint", "No Internet Connection!");
    //         return;
    //     }
    //     else
    //     {
    //         string Version;
    //     }
    // }
}
