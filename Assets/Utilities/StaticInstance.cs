using UnityEngine;

namespace Assets.Utilities
{
    /// <summary>
    /// A static instance is similar to a singleton, but instead of destroying any new
    /// instances, it overrides the current instance. This is handy for resetting the state
    /// and saves you doing it manually
    /// </summary>
    public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }
        protected virtual void Awake() => Instance = this as T;

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// One per scene singleton
    /// </summary>
    public abstract class ScenewideSingleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            base.Awake();
        }
    }

    /// <summary>
    /// One per app singleton
    /// </summary>
    public abstract class AppwideSingleton<T> : ScenewideSingleton<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}
