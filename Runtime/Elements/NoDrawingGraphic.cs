using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UI;
#endif

namespace Lab5Games.UI
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class NoDrawingGraphic : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(NoDrawingGraphic))]
    public class NoDrawingGraphicEditor : GraphicEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}

