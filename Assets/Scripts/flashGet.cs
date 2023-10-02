using UnityEngine;
using System.Collections;

public class flashGet : MonoBehaviour
{
    public bool flashHave = false;
    public Texture2D flashOn;
    public Texture2D flashOff;
    public Light flashlightLightSource;
    public AudioClip soundTurnOn;
    public AudioClip soundTurnOff;
    public bool lightOn = false;
    public AudioSource audioSource;

    void Update()
    {
        if (flashHave && Input.GetKeyUp(KeyCode.H))
        {
            flashlightLightSource.enabled = !lightOn;
            GetComponent<GUITexture>().texture = lightOn ? flashOff : flashOn;
            audioSource.clip = flashlightLightSource.enabled ? soundTurnOn : soundTurnOff;
            audioSource.Play();
            lightOn = !lightOn;
        }
    }
}
