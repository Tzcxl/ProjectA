using Assets.Unit;
using UnityEditor;

namespace Assets._Scripts
{
    [CustomEditor(typeof(UnitScript))]
    public class RealStatsCustomEditor : Editor
    {
        private bool _show;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var unit = (UnitScript)target;
            if (unit.Stats == null) return;

            _show = EditorGUILayout.Foldout(_show, "Stats");
            if (!_show) return;

            var editor = CreateEditor(unit.Stats);
            editor.OnInspectorGUI();
        }
    }
}
