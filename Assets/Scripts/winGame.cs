using UnityEngine;
using System.Collections;

public class winGame : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        GameObject.Find("winGUI").GetComponent<GUIText>().text = "暂时安全了，但与此同时…";
        StartCoroutine(WaitForText());
    }

    IEnumerator WaitForText()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("winGUI").GetComponent<Animation>().Play();
        GameObject.Find("winGUI").GetComponent<GUIText>().text = "未完待续…";
        yield return new WaitForSeconds(2);
        GameObject.Find("winGUI").GetComponent<GUIText>().text = "";
        Application.LoadLevel("menu");
    }
}