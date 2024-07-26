using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Utilities
{
    /// <summary>
    /// A static class for general helpful methods
    /// </summary>
    public static class Helpers
    {
        private static Camera _camera;
        private static List<RaycastResult> _results = new();
        private static readonly Dictionary<float, WaitForSeconds> _waitDict = new();

        public static Camera Camera
        {
            get
            {
                if (_camera == null) _camera = Camera.main;
                return _camera;
            }
        }

        /// <summary>
        /// IS the pointer over UI?
        /// </summary>
        public static bool IsOverUI
        {
            get
            {
                _results.Clear();
                var eventDataCurrentPosition = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
                EventSystem.current.RaycastAll(eventDataCurrentPosition, _results);
                return _results.Count > 0;
            }
        }

        /// <summary>
        /// Non-allocating WaitForSeconds
        /// </summary>
        public static WaitForSeconds GetWait(float seconds)
        {
            if (_waitDict.TryGetValue(seconds, out WaitForSeconds wait))
                return wait;

            _waitDict[seconds] = new WaitForSeconds(seconds);
            return _waitDict[seconds];
        }

        /// <summary>
        /// find world point of canvas element
        /// </summary>
        public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera, out var result);
            return result;
        }

        /// <summary>
        /// Destroy all child objects of this transform (Unintentionally evil sounding).
        /// Use it like so:
        /// <code>
        /// transform.DestroyChildren();
        /// </code>
        /// </summary>
        public static void DestroyChildren(this Transform t)
        {
            foreach (Transform child in t)
                Object.Destroy(child.gameObject);
        }
    }
}