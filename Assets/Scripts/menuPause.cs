using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuPause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Slider slider;
    public AudioSource audioSource;
	public GameObject isPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnGame();
        }
    }
    public void ReturnGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused.guiText.text = "false";
    }
    public void ReturnMainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("menu");
        isPaused.guiText.text = "false";
    }

    public void OnValueChanged()
    {
        audioSource.volume = slider.value;
    }


}
