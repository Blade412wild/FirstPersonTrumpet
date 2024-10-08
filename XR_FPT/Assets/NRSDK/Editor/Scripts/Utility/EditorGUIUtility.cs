﻿using System;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using Object = UnityEngine.Object;

public static class NREditorUtility
{
    [Conditional("UNITY_EDITOR_WIN"), Conditional("UNITY_STANDALONE_WIN"), Conditional("UNITY_ANDROID")]
    public static void BoolField(Object target, string name, ref bool member, ref bool modified)
    {
        BoolField(target, new GUIContent(name), ref member, ref modified);
    }

    [Conditional("UNITY_EDITOR_WIN"), Conditional("UNITY_STANDALONE_WIN"), Conditional("UNITY_ANDROID")]
    public static void BoolField(Object target, GUIContent name, ref bool member, ref bool modified)
    {
        EditorGUI.BeginChangeCheck();
        bool value = EditorGUILayout.Toggle(name, member);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed " + name);
            member = value;
            modified = true;
        }
    }

    [Conditional("UNITY_EDITOR_WIN"), Conditional("UNITY_STANDALONE_WIN"), Conditional("UNITY_ANDROID")]
    public static void Popup(Object target, string name, ref Enum select, ref bool modified)
    {
        Popup(target, new GUIContent(name), ref select, ref modified);
    }

    [Conditional("UNITY_EDITOR_WIN"), Conditional("UNITY_STANDALONE_WIN"), Conditional("UNITY_ANDROID")]
    public static void Popup(Object target, GUIContent name, ref Enum select, ref bool modified)
    {
        EditorGUI.BeginChangeCheck();
        var value = EditorGUILayout.EnumPopup(name, select);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed " + name);
            select = value;
            modified = true;
        }
    }

    [Conditional("UNITY_EDITOR_WIN"), Conditional("UNITY_STANDALONE_WIN"), Conditional("UNITY_ANDROID")]
    public static void ObjectField<T>(Object target, Object member, string name, bool allowScene, Action<T> act, ref bool modified) where T : class
    {
        ObjectField<T>(target, member, new GUIContent(name), allowScene, act, ref modified);
    }

    [Conditional("UNITY_EDITOR_WIN"), Conditional("UNITY_STANDALONE_WIN"), Conditional("UNITY_ANDROID")]
    public static void ObjectField<T>(Object target, Object member, GUIContent name, bool allowScene, Action<T> act, ref bool modified) where T : class
    {
        EditorGUI.BeginChangeCheck();
        Object value = EditorGUILayout.ObjectField(name, member, typeof(T), allowScene);
        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Changed " + name);
            act?.Invoke(value as T);
            modified = true;
        }
    }
}