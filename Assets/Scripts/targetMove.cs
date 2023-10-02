using UnityEngine;
using System.Collections;

public class targetMove : MonoBehaviour
{
    public float speed = 3f; // 靶子的移动速度
    public float distance = 1.2f; // 靶子移动的距离

    private Vector3 startPosition; // 靶子的起始位置
    private float direction = 1f; // 靶子的移动方向
    public bool targetGameIsOver = false;
    public GameObject flash;
    public GameObject key;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (targetGameIsOver == true)
        {
            return;
        }
        if (GameObject.Find("target2").GetComponent<TargetCollision>().targetScore == 3)
        {
            targetGameIsOver = true;
            GameObject.Find("fps-glock").SetActive(false);
            GameObject.Find("Launcher").SetActive(false);
            GameObject.Find("BackMusic").GetComponent<GUITexture>().enabled = false;
            Instantiate(flash, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            Instantiate(key, transform.position, Quaternion.identity);
        }
        else
        {        // 计算靶子的新位置
            float newPosition = transform.position.z + direction * speed * Time.deltaTime;

            // 如果靶子超出了移动范围，改变移动方向
            if (Mathf.Abs(newPosition - startPosition.z) > distance)
            {
                direction = -direction;
            }
            // 更新靶子的位置
            else
            {
                transform.position = new Vector3(startPosition.x, startPosition.y, newPosition);
            }
        }
    }

}