using UnityEngine;
using System.Collections;

public class MathGameController : MonoBehaviour
{
    public GUIText mathText; // 用于显示题目和选项
    private int num1;
    private int num2;
    private int answer;
    private int[] options = new int[3];
    private float timer = 0f; // 计时器
    private bool isGenerating = false; // 是否正在生成题目
    public Transform playerTransform; // 玩家的Transform组件
    public Vector3 respawnPosition = new Vector3(23.76f, 1.75f, -1.054f); // 重新生成位置
    public int score = 0; // 分数
    public bool isOver = false; // 是否结束
    public GameObject key; // 钥匙
    void Start()
    {
        GenerateMathProblem();
    }
    void Update()
    {
        if (!isOver && isGenerating)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                GenerateMathProblem();
                playerTransform.position = respawnPosition;
            }
            // // 如果按下键盘A
            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     CheckAnswer("A");
            // }
            // // 如果按下键盘B
            // if (Input.GetKeyDown(KeyCode.B))
            // {
            //     CheckAnswer("B");
            // }
            // // 如果按下键盘C
            // if (Input.GetKeyDown(KeyCode.C))
            // {
            //     CheckAnswer("C");
            // }
        }
    }
    void GenerateMathProblem()
    {
        if (!isGenerating && !isOver)
        {
            // 生成两个随机数字
            num1 = Random.Range(1, 10);
            num2 = Random.Range(1, 10);

            // 生成一个随机运算符
            int op = Random.Range(0, 3);
            mathText.text = "还需答对" + (3 - score).ToString() + "道题目\n";
            // 根据运算符计算正确答案
            switch (op)
            {
                case 0:
                    answer = num1 + num2;
                    mathText.text += num1 + " + " + num2 + " = ?";
                    break;
                case 1:
                    answer = num1 - num2;
                    mathText.text += num1 + " - " + num2 + " = ?";
                    break;
                case 2:
                    answer = num1 * num2;
                    mathText.text += num1 + " × " + num2 + " = ?";
                    break;
            }

            // 生成三个随机选项
            for (int i = 0; i < 3; i++)
            {
                options[i] = Random.Range(answer - 5, answer + 5);
                if (options[i] == answer)
                {
                    options[i] += 1;
                }
            }

            // 将正确答案插入到选项中的随机位置
            int index = Random.Range(0, 3);
            options[index] = answer;

            // 将题目和选项显示在mathText组件中
            mathText.text += "\nA. " + options[0] + "\nB. " + options[1] + "\nC. " + options[2];

            // 开始计时
            timer = 0f;
            isGenerating = true;
        }
    }
    public void CheckAnswer(string option)
    {
        Debug.Log(option);
        if (!isGenerating)
        {
            return;
        }

        int selectedOption = -1;
        switch (option)
        {
            case "A":
                selectedOption = options[0];
                break;
            case "B":
                selectedOption = options[1];
                break;
            case "C":
                selectedOption = options[2];
                break;
        }

        if (selectedOption == answer)
        {
            // 答案正确，给予奖励
            Debug.Log("Correct answer!");
            score++;
            if (score == 3)
            {
                isOver = true;
                mathText.text = "";
                Vector3 newPosition = playerTransform.position;
                newPosition.x += 10f;
                playerTransform.position = newPosition;
                GameObject.Find("AnswerA").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("AnswerB").GetComponent<BoxCollider>().enabled = false;
                GameObject.Find("AnswerC").GetComponent<BoxCollider>().enabled = false;

                Instantiate(key, GameObject.Find("AnswerB").transform.position, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("Wrong answer!");
        }
        playerTransform.position = respawnPosition;
        isGenerating = false;
        GenerateMathProblem();
    }

}
