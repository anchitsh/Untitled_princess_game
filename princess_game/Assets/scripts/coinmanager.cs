using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class coinmanager : MonoBehaviour
{
    public int totalcoins, totalgems;
    public static int coin, gem;
    public Text coinText, gemtext;
    int temp;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
        gem = 0;

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coin.ToString() + "/" + totalcoins.ToString();
        gemtext.text = gem.ToString() + "/" + totalgems.ToString();
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
