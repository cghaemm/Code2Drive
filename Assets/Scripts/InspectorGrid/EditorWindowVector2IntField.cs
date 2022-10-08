using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorWindowVector2IntField : EditorWindow
{
    private const string controlName = "Vector2IntField";
    private static bool controlFocused;

    public delegate void OnApply(Vector2Int newSize);

    private static Vector2Int newFieldValue;
    private static string fieldLabel;
    private static OnApply onApply;

}
