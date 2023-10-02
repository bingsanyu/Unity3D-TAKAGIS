using UnityEngine;
using System.Collections;

public class key : MonoBehaviour
{
    public Texture2D keyOff;
    public Texture2D keyOn;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 播放音效
            //GetComponent<AudioSource>().Play();
            GameObject.Find("haveKey").GetComponent<GUIText>().text = "X" + (++GameObject.Find("haveKey").GetComponent<keyGet>().keyNum).ToString();
            GameObject.Find("haveKey").GetComponent<GUITexture>().texture = keyOff;
            GameObject.Find("keyParticle").SetActive(false);
            if (GameObject.Find("haveKey").GetComponent<keyGet>().keyNum == 1)
            {
                GameObject.Find("haveKey").GetComponent<GUITexture>().texture = keyOff;
                GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("获得了一个钥匙碎片，好像需要三个碎片才能拼成钥匙");
                GameObject.Find("doorLight").GetComponent<Light>().color = Color.yellow;
            }
            else if (GameObject.Find("haveKey").GetComponent<keyGet>().keyNum == 3)
            {
                GameObject.Find("haveKey").GetComponent<GUITexture>().texture = keyOn;
                GameObject.Find("haveKey").GetComponent<keyGet>().keyHave = true;
                GameObject.Find("doorLight").GetComponent<Light>().color = Color.green;
            }
            Destroy(gameObject);
        }
    }

}
