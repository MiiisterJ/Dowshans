using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

#region Read Only Inspector
public class ReadOnlyAttribute : PropertyAttribute
{

}


[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property,
                                            GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position,
                               SerializedProperty property,
                               GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endregion

public class GameLogic : MonoBehaviour
{
    public PartyMember[] Character = new PartyMember[4]; // In the box, put numbers from 0 to 3.

    int GameMode;

    [ReadOnly] [SerializeField]
    int testOutput;

    // Start is called before the first frame update
    void Start()
    {
        UI_Update();
        testOutput++;
    }

    // Update is called once per frame
    void Update()
    {
        //UI_Update();
        //testOutput++;
    }

    void LoadFile_ExperiencePoints()
    {

    }

    void UI_Update()
    {
        Text UITextBox;
        for (int i = 0; i < 4; i++)
        {
            switch (Character[i].MemberID)
            {
                case 1:
                    UITextBox = GameObject.Find("Rocky UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
                case 2:
                    UITextBox = GameObject.Find("Luke UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
                case 3:
                    UITextBox = GameObject.Find("Jane UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
                case 4:
                    UITextBox = GameObject.Find("Phoenix UI").GetComponent<Text>();
                    UITextBox.text = Character[i].Name + " Lvl. " + Character[i].Level;
                    break;
            }
        }
    }
}
