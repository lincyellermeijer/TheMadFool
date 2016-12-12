using UnityEngine;
using System.Collections;

public class NPC_Dialog : MonoBehaviour {

    public string[] answerButtons;
    public string[] questions;
    public int rewardAmount;
    public Font myFont;
    bool displayDialog = false;
    public bool activateQuest = false;
    public bool hasDoneQuest = false;

    public Texture questSymbol;

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.font = myFont;
        myStyle.fontSize = 20;
        myStyle.normal.textColor = Color.white;

        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.font = myFont;
        myButtonStyle.normal.textColor = Color.white;
        myButtonStyle.hover.textColor = Color.cyan;


        GUILayout.BeginArea(new Rect(300, 100, 400, 400), myStyle);

        if (displayDialog && !activateQuest)
        {
            GUILayout.Label(questions[0], myStyle);
            GUILayout.Label(questions[1], myStyle);
            
            if(GUILayout.Button(answerButtons[0], myButtonStyle))
            {
                activateQuest = true;
                hasDoneQuest = false;
                displayDialog = false;
            }

            if (GUILayout.Button(answerButtons[1], myButtonStyle))
            {
                displayDialog = false;
            }
        }

        if(displayDialog && activateQuest && hasDoneQuest)
        {
            GUILayout.Label(questions[2], myStyle);

            if(GUILayout.Button(answerButtons[2], myButtonStyle))
            {
                questCompleted();
                displayDialog = false;
            }
        }

        GUILayout.EndArea();

        if(activateQuest == true)
        {
            GUILayout.BeginArea(new Rect(5, 5, 150, 150));

            GUIStyle myBoxStyle = new GUIStyle(GUI.skin.box);
            myBoxStyle.font = myFont;
            myBoxStyle.normal.textColor = Color.white;

            GUILayout.Box("Quest active : ", myBoxStyle);

            GUILayout.EndArea();

            GUI.DrawTexture(new Rect(50, 40, 50, 50), questSymbol);
        }
    }

    void OnTriggerEnter2D()
    {
        displayDialog = true;
    }

    void OnTriggerExit2D()
    {
        displayDialog = false;
    }

    void questCompleted()
    {
        PlayerEXP.playerEXP += rewardAmount;
        GameObject.Destroy(GetComponent<BoxCollider2D>());
        activateQuest = false;
    }
}

