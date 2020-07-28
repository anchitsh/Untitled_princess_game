using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossUI : MonoBehaviour
{
    public GameObject healthbar, underbar;
    private static Image HealthBarImage, underBarImage;
    [Header("Blink")]
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    Color32 red, underbarcolor;
    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public static void decrease()
    {
        HealthBarImage.fillAmount -= 0.05f;

    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        HealthBarImage = healthbar.GetComponent<Image>();
        underBarImage = underbar.GetComponent<Image>();
        red = HealthBarImage.color;
        underbarcolor = underBarImage.color;
       // StartCoroutine(blood());
    }
    private void Update()
    {
        if (HealthBarImage.fillAmount < 0.25f)
        {
            SpriteBlinkingEffect();
        }
    }
    private IEnumerator blood()
    {
        while (true)
        {
            decrease();
            yield return new WaitForSeconds(1);

        }
    }
     void SpriteBlinkingEffect()
    {
        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (HealthBarImage.color == red)
            {
                HealthBarImage.color = underbarcolor;  //make changes
            }
            else
            {
                HealthBarImage.color = red;   //make changes
            }
        }
    }
}
