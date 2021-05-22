using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ExampleMethodCaller
{
    [ExecuteAlways]
    public class Example : MonoBehaviour
    {
        public void PublicMethod()
        {
            print("PublicMethod");
        }

        private void PrivateMethod()
        {
            print("PrivateMethod");
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Example))]
    public class ExampleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Example t = target as Example;

            if (GUILayout.Button("PublicMethod"))
            {
                t.PublicMethod();
            }

            if (GUILayout.Button("PrivateMethod"))
            {
                t.SendMessage("PrivateMethod", null, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
#endif
}
