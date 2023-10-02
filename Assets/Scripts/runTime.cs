using UnityEngine;
using System.Collections;

public class runTime : MonoBehaviour
{
    // 如果按下esc键，暂停游戏
    public GameObject MenuPause;
	public GameObject IsPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            IsPaused.guiText.text = "true";
            MenuPause.SetActive(true);
        }
    }
}
