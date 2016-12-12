using UnityEngine;
using System.Collections;

public class EXPCollected : MonoBehaviour {

    public Font myFont;
    public PlayerEXP playerExp;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(5, 565, 150, 150));

        GUIStyle myStyle = new GUIStyle(GUI.skin.box);
        myStyle.font = myFont;
        myStyle.normal.textColor = Color.white;

        GUILayout.Box("EXP:  " + PlayerEXP.playerEXP, myStyle);

        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(805, 565, 150, 150));

        GUIStyle myStaminaStyle = new GUIStyle(GUI.skin.box);
        myStaminaStyle.font = myFont;
        myStaminaStyle.normal.textColor = Color.white;

        GUILayout.Box("Stamina:  " + playerExp.maxStamina, myStaminaStyle);

        GUILayout.EndArea();
    }
}
