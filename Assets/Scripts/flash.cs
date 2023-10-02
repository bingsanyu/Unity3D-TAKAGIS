using UnityEngine;
using System.Collections;

public class flash : MonoBehaviour
{
    public Texture2D flashOff;
    void Update()
    {
        // 旋转
        transform.Rotate(Vector3.forward * Time.deltaTime * 100);

    }

	// 碰撞器拾取
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			// 播放音效
			//GetComponent<AudioSource>().Play();
			// 拾取后消失
			GameObject.Find("haveFlash").GetComponent<flashGet>().flashHave = true;
			GameObject.Find("haveFlash").GetComponent<GUITexture>().texture = flashOff;
			GameObject.Find("flashParticle").SetActive(false);
			GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("获得了一个手电筒，按H键使用");
			
			Destroy(gameObject);
			// 拾取后显示
		}
	}
	
}
