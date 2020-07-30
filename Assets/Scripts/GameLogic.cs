using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

#region Read Only Inspector
#if DEBUG
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

#endif
#endregion

public class GameLogic : MonoBehaviour
{
    public Scene ActiveScene;
    public string SceneName;
    public LoadSceneMode SceneMode;

    public PartyMember[] Character = new PartyMember[4];

    int GameMode;
    public bool UpdateUI;
#if DEBUG
    [ReadOnly] [SerializeField]
#endif
    int testOutput;


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        testOutput++;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveScene = SceneManager.GetActiveScene();
        if (SceneName != ActiveScene.name)
        {
            SceneName = ActiveScene.name;
            if (SceneName == "Rocky Mountains" || SceneName == "Dark Castle")
                UI_Update();
        }

        if (UpdateUI)
        {
            //if (SceneName == "Rocky Mountains" || SceneName == "Dark Castle")
                UI_Update();
            testOutput++;
            UpdateUI = false;
        }
    }

    void LoadFile_ExperiencePoints()
    {

    }

    void UI_Update()
    {
        Text UITextBox;
        for (int i = 0; i < Character.Length; i++)
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
