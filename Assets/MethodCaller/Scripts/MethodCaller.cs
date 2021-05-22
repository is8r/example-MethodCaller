using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ExampleMethodCaller
{
    [ExecuteAlways]
    public class MethodCaller : MonoBehaviour
    {
        public List<UnityEvent> OnEvent;

        public void Action (int id)
        {
            OnEvent[id].Invoke ();
        }
    }

#if UNITY_EDITOR
    [ExecuteAlways]
    [CustomEditor (typeof (MethodCaller))]
    public class MethodCallerEditor : Editor
    {
        public override void OnInspectorGUI ()
        {
            base.OnInspectorGUI ();

            MethodCaller t = target as MethodCaller;
            if (t == null) return;
            if (t.OnEvent == null) return;
            if (t.OnEvent.Count > 1)
            {
                for (int i = 0; i < t.OnEvent.Count; i++)
                {
                    if (t.OnEvent[i].GetPersistentEventCount () > 0 && t.OnEvent[i].GetPersistentMethodName (0).Length > 0)
                    {
                        if (GUILayout.Button (t.OnEvent[i].GetPersistentMethodName (0)))
                        {
                            t.Action (i);
                        }
                    }
                }
            }
        }
    }
#endif
}
