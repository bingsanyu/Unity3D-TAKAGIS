using UnityEngine;
using System.Collections;

public class mathGameStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("BackMusic").GetComponent<messageShow>().ShowMessage("答题时间！");
            Invoke("mathGamePre", 2f);
        }
    }
    void mathGamePre()
    {
        GameObject.Find("mathGame").GetComponent<MathGameController>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
