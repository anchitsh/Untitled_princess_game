using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinmanager : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    int temp;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("coins", 0);

        //scoreText.text = 
        temp = score;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (temp < score)
        {
            int num = getlen(score);
            switch (num)
            {
                case 1:
                    scoreText.text = "000000"+score.ToString();
                    break;
                case 2:
                    scoreText.text = "00000" + score.ToString();
                    break;
                case 3:
                    scoreText.text = "0000" + score.ToString();
                    break;
                case 4:
                    scoreText.text = "0000" + score.ToString();
                    break;
                case 5:
                    scoreText.text = "000" + score.ToString();
                    break;
                case 6:
                    scoreText.text = "00" + score.ToString();
                    break;
                case 7:
                    scoreText.text ="0"+ score.ToString();
                    break;
            }
            temp = score;
        }
    }

    int getlen(int num)
    {
        int count = 0;
        do
        {
            count++;
            num = num / 10;


        } while (num !=0);

        return count;
    }
}
