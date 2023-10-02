using UnityEngine;
using System.Collections;

public class runGameStart : MonoBehaviour
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
            GameObject.Find("xigua8").GetComponent<chaser>().enabled = true;
        }
    }
}
