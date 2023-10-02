using UnityEngine;
using System.Collections;

public class menuWeb : MonoBehaviour
{

    // Use this for initialization
    IEnumerator OnMouseUp()
    {
        Application.OpenURL("https://www.bilibili.com/video/BV1RY4y197oL/");
		yield return new WaitForSeconds(0.3f);
    }
}
