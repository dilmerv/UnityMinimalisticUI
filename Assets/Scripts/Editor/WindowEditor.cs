using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CustomEditor(typeof(Window))]
public class WindowEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Window customWindowEditor = (Window)target;

        EditorGUILayout.LabelField("Window Settings");

        customWindowEditor.WindowHeaderTitle = EditorGUILayout
            .TextField("Window Header Title", customWindowEditor.WindowHeaderTitle);

        customWindowEditor.HeaderTextGameObject = (Text)EditorGUILayout
            .ObjectField("Window Header Game Object", customWindowEditor.HeaderTextGameObject, typeof(Text));

        customWindowEditor.StartHidden = EditorGUILayout
            .Toggle("Start Hidden", customWindowEditor.StartHidden);

        customWindowEditor.Animation = (UIComponent.AnimationType)EditorGUILayout
            .EnumPopup("Animation Type", customWindowEditor.Animation);

        if(customWindowEditor.Animation == UIComponent.AnimationType.Fade)
        {
            customWindowEditor.FadeDuration = EditorGUILayout
                .FloatField("Fade Duration", customWindowEditor.FadeDuration);
        }
        else if(customWindowEditor.Animation == UIComponent.AnimationType.Movement)
        {
            customWindowEditor.MoveDuration = EditorGUILayout
                .FloatField("Move Duration", customWindowEditor.MoveDuration);

            customWindowEditor.MoveFrom = EditorGUILayout
                .Vector3Field("Move From", customWindowEditor.MoveFrom);

            customWindowEditor.MoveTo = EditorGUILayout
                .Vector3Field("Move To", customWindowEditor.MoveTo);
        }

        EditorGUILayout.LabelField("Window Unity Events");

        SerializedProperty onOpen = serializedObject.FindProperty("onOpen"); // unity event
        EditorGUILayout.PropertyField(onOpen);

        SerializedProperty onClose = serializedObject.FindProperty("onClose"); // unity event
        EditorGUILayout.PropertyField(onClose);
    
        if(GUI.changed){
            serializedObject.ApplyModifiedProperties();
        }
    }
}
