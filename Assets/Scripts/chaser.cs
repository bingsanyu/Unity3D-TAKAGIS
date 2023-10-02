using UnityEngine;
using System.Collections;

public class chaser : MonoBehaviour
{
    public Transform player;
    public float speed = 6.0f;
    public float chaseDistance = 10.0f;
    public float resetTime = 10.0f;
    public float slowSpeed = 3.0f; // 光线照射到追逐者时的速度
    public GUIText timerText;
    private float timer;
    private bool isSlowed = false; // 是否被减速
    public GameObject FlashLight;
    public GameObject key;
    void Start()
    {
        timer = resetTime;
    }
    void Update()
    {
        // 计时器
        timer -= Time.deltaTime;
        timerText.text = "快跑！剩余时间: " + timer.ToString("F1") + "\n提示：用手电筒照射";
        // 如果计时器归零，则重置计时器和追逐者状态
        if (timer <= 0)
        {
            Instantiate(key, transform.position, Quaternion.identity);
            timerText.text = "";
            Destroy(gameObject);
        }

        // 如果 手电筒的light组件开启
        if (FlashLight.GetComponent<Light>().enabled)
        {
            Transform playerTransform = player.GetComponent<Transform>();
            float angle = Vector3.Angle(player.transform.forward, transform.position - player.transform.position);
            Debug.Log(angle);
            if (angle < 45.0f)
            {
                if (!isSlowed)
                {
                    speed = slowSpeed; // 玩家面对着追逐者时的速度
                    isSlowed = true;
                }
            }
            else
            {
                speed = 5.0f; // 玩家没有面对着追逐者时的速度
                isSlowed = false;
            }
        }
        else
        {
            speed = 5.0f;
        }

        // 如果追逐者没有追上玩家，则继续追逐
        if (Vector3.Distance(transform.position, player.position) > 1.0f)
        {
            transform.LookAt(player);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        // 如果追逐者追上了玩家，则重置计时器和追逐者状态，并将钥匙设置为未获得
        else if (Vector3.Distance(transform.position, player.position) <= 1.0f)
        {
            timer = resetTime;
        }
    }
}