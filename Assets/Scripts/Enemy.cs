using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

public class Enemy : MonoBehaviour
{
    EnemyStats Monster;
    [ReadOnly]
    [SerializeField]
    string Name;
    public TextMesh TextTest;

    public int MonsterID;
    public bool Boss;
    public int Level;

    // Start is called before the first frame update
    void Start()
    {
        Monster = new EnemyStats(MonsterID, Boss, Level);
        Name = Monster.Name;
        TextTest.text = Name + " lvl. " + Monster.Level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
