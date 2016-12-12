using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeSystem : MonoBehaviour
{
    public PlayerEXP playerExp;
    public Font myFont;
    private bool isStaminaSkillUnlocked = false;
    private bool notEnoughExp = false;
    public int maxStaminaLv1 = 2;
    public int staminaLv1SkillPrice = 250;
    public Text sorryText;
    public Text buyText;

    void Start()
    {
        sorryText.enabled = false;
        buyText.enabled = false;
    }

    void OnGUI()
    {

        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.font = myFont;
        myButtonStyle.normal.textColor = Color.white;
        myButtonStyle.hover.textColor = Color.cyan;

        if (GUI.Button(new Rect(830, 5, 120, 30), "Stamina Lv1", myButtonStyle))
        {
            if (PlayerEXP.playerEXP >= staminaLv1SkillPrice)
            {
                isStaminaSkillUnlocked = true;
                PlayerEXP.playerEXP -= staminaLv1SkillPrice;
                playerExp.maxStamina += maxStaminaLv1;
            }
            else if (PlayerEXP.playerEXP < staminaLv1SkillPrice)
            {
                notEnoughExp = true;
            } 
        }

        if (notEnoughExp == true)
        {
            sorryText.enabled = true;
            sorryText.text = "Sorry, but you don't have enough EXP to unlock this skill! It costs 250 EXP.";
            if (GUI.Button(new Rect(400, 320, 120, 30), "OK!", myButtonStyle))
            {
                sorryText.enabled = false;
                notEnoughExp = false;
            }
        }

        if (isStaminaSkillUnlocked == true)
        {
            buyText.enabled = true;
            buyText.text = "You have bought the Max Stamina Lv1 Skill!";

            if (GUI.Button(new Rect(400, 320, 120, 30), "OK!", myButtonStyle))
            {
                buyText.enabled = false;
                isStaminaSkillUnlocked = false;
            }

            else if (isStaminaSkillUnlocked == false)
            {
                playerExp.maxStamina = 2;
            }
        }
    }
}
