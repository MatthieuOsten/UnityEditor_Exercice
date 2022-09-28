using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ComponentString))]
public class EditorComponentString : Editor
{
    public SerializedProperty valueString;

    public override void OnInspectorGUI()
    {

        DisplayStringValue("valueString");

    }

    private void DisplayStringValue(string property)
    {
        serializedObject.Update();

        // Recupere la proprieter voulue
        valueString = serializedObject.FindProperty(property);

        // Recupere le nom de la variable
        string nameValue = "---- " + valueString.name + " ----";

        // Affiche le nom de la variable au milieu de 
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField(nameValue, EditorStyles.largeLabel);
        EditorGUILayout.EndHorizontal();

        // Affiche le tooltip de la variable string
        EditorGUILayout.LabelField(valueString.tooltip, EditorStyles.miniBoldLabel);

        // Met a disposition un moyen de modifier la variable string
        valueString.stringValue = EditorGUILayout.TextArea(valueString.stringValue);

        // Affiche le contenu de la variable
        EditorGUILayout.LabelField(valueString.stringValue, EditorStyles.whiteMiniLabel);

        // Applique les modification
        serializedObject.ApplyModifiedProperties();
    }
}
