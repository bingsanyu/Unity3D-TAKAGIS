using UnityEngine;
using System.Collections;

public class TargetCollision : MonoBehaviour
{
    Animation targetRoot;
    public AudioClip hitSound;
    private bool beenHit = false;

    public int targetScore = 0; // 分数
    void Start()
    {
        targetRoot = transform.parent.transform.parent.animation;
    }
    void OnCollisionEnter(Collision col)
    {
        if (beenHit == false && col.gameObject.name == "cell")
        {
            StartCoroutine("targetHit");
        }
    }
    IEnumerator targetHit()
    {
        targetRoot.Play("down");
        // audio.PlayOneShot(hitSound);
        beenHit = true;
        yield return new WaitForSeconds(1.0f);
        if (++targetScore != 3)
        {
            targetRoot.Play("up");
            beenHit = false;
        }
    }
}
