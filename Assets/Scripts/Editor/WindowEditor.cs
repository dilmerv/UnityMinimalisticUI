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

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Window Settings", EditorStyles.boldLabel);

        EditorGUILayout.Separator();

        customWindowEditor.WindowHeaderTitle = EditorGUILayout
            .TextField("Window Header Title", customWindowEditor.WindowHeaderTitle);

        customWindowEditor.HeaderTextGameObject = (Text)EditorGUILayout
            .ObjectField("Window Header Game Object", customWindowEditor.HeaderTextGameObject, typeof(Text));

        customWindowEditor.StartHidden = EditorGUILayout
            .Toggle("Start Hidden", customWindowEditor.StartHidden);


        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Window Animations", EditorStyles.boldLabel);

        EditorGUILayout.Separator();
        // For Animation In

        customWindowEditor.AnimationIn = (UIComponent.AnimationType)EditorGUILayout
            .EnumPopup("In Animation Type", customWindowEditor.AnimationIn);

        if(customWindowEditor.AnimationIn == UIComponent.AnimationType.Fade)
        {
            customWindowEditor.FadeInDuration = EditorGUILayout
                .FloatField("Fade In Duration", customWindowEditor.FadeInDuration);
        }
        else if(customWindowEditor.AnimationIn == UIComponent.AnimationType.Movement)
        {
            customWindowEditor.MoveInDuration = EditorGUILayout
                .FloatField("Move In Duration", customWindowEditor.MoveInDuration);

            customWindowEditor.MoveInFrom = EditorGUILayout
                .Vector3Field("Move In From", customWindowEditor.MoveInFrom);

            customWindowEditor.MoveInTo = EditorGUILayout
                .Vector3Field("Move In To", customWindowEditor.MoveInTo);
        }

        EditorGUILayout.Separator();

        customWindowEditor.AnimationOut = (UIComponent.AnimationType)EditorGUILayout
            .EnumPopup("Out Animation Type", customWindowEditor.AnimationOut);

        // For Animation Out
        if(customWindowEditor.AnimationOut == UIComponent.AnimationType.Fade)
        {
            customWindowEditor.FadeOutDuration = EditorGUILayout
                .FloatField("Fade Out Duration", customWindowEditor.FadeOutDuration);
        }
        else if(customWindowEditor.AnimationOut == UIComponent.AnimationType.Movement)
        {
            customWindowEditor.MoveOutDuration = EditorGUILayout
                .FloatField("Move Out Duration", customWindowEditor.MoveOutDuration);

            customWindowEditor.MoveOutFrom = EditorGUILayout
                .Vector3Field("Move Out From", customWindowEditor.MoveOutFrom);

            customWindowEditor.MoveOutTo = EditorGUILayout
                .Vector3Field("Move Out To", customWindowEditor.MoveOutTo);
        }

        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("Window Unity Events", EditorStyles.boldLabel);

        SerializedProperty onOpen = serializedObject.FindProperty("onOpen"); // unity event
        EditorGUILayout.PropertyField(onOpen);

        SerializedProperty onClose = serializedObject.FindProperty("onClose"); // unity event
        EditorGUILayout.PropertyField(onClose);
    
        if(GUI.changed){
            serializedObject.ApplyModifiedProperties();
        }
    }
}
