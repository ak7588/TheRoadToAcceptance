using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GateColorManager : MonoBehaviour
{
    public float transitionSpeed = 1.0f;
    //this changes the transition property
    private float _transition = 0;

    public GateColorControl[] gates;

    public float transition
    {

        get
        {
            return _transition;

        }
        set
        {
            _transition = Mathf.Clamp01(value);

            foreach (GateColorControl obj in gates)
            {
                obj.transition = _transition;
            }

        }

    }

    public void TransitionColors()
    {
        StartCoroutine(AnimateColor());
    }

    IEnumerator AnimateColor()
    {
        while (!Mathf.Approximately(_transition, 1.0f))
        {
            transition = Mathf.MoveTowards(transition, 1.0f, transitionSpeed * Time.deltaTime);
            yield return null;
        }
    }

}

#if UNITY_EDITOR

[CustomEditor(typeof(GateColorManager))]
class GateColorManagerEditor : Editor {

    public override void OnInspectorGUI()
    {
    //This is what you would call in another script
    //For example, make a position a triger and then run this part of the script. 
        GateColorManager manager = target as GateColorManager;

        manager.transition = EditorGUILayout.Slider("Transition", manager.transition, 0.0f, 1.0f);

        if(GUILayout.Button("Transition")) {
             manager.TransitionColors();
         }

        DrawDefaultInspector();
    }

}

#endif
