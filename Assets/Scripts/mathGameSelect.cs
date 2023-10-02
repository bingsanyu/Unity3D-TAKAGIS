using UnityEngine;
using System.Collections;

public class mathGameSelect : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "AnswerB")
            {
                // 传递参数"A"给MathGameController.cs
                GameObject.Find("mathGame").SendMessage("CheckAnswer", "A");

            }
            else if (gameObject.tag == "AnswerB")
            {
                GameObject.Find("mathGame").SendMessage("CheckAnswer", "B");
            }
            else if (gameObject.tag == "AnswerC")
            {
                GameObject.Find("mathGame").SendMessage("CheckAnswer", "C");
            }
        }
    }
}