using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

//[CustomEditor(typeof(LevelProbability))]
//[CanEditMultipleObjects]
public class LevelGeneratorEditor : Editor
{
    private ReorderableList list;

    void OnEnable()
    {
        list = new ReorderableList(serializedObject,
                serializedObject.FindProperty("levelPrefabs"),
                true, true, true, true);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
