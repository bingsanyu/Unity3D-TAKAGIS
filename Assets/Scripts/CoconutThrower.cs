using UnityEngine;
using System.Collections;

public class CoconutThrower : MonoBehaviour
{
    public Rigidbody coconut;
    public AudioClip throwSound;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody cell = Instantiate(coconut, transform.position, transform.rotation) as Rigidbody;
			cell.name = "cell";
            cell.velocity = transform.forward * 30;
            GetComponent<AudioSource>().PlayOneShot(throwSound);
        }
    }


}
