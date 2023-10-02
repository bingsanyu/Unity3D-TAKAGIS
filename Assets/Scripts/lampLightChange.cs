using UnityEngine;
using System.Collections;

public class lampLightChange : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GameObject.Find("haveKey").GetComponent<keyGet>().keyNum == 1)
        {
            // 随机数
            float ran = Random.Range(0, 100);
            // 灯光强度
            float light = GetComponent<Light>().intensity;
            // 灯光强度随机变化
            if (ran < 50)
            {
                light += 1f;
            }
            else
            {
                light -= 1f;
            }
            // 灯光强度限制
            if (light > 8)
            {
                light = 1;
            }
            if (light < 0)
            {
                light = 0;
            }
            // 灯光强度变化
            GetComponent<Light>().intensity = light;
        }
    }
}
