using UnityEngine;
namespace DesignPattern
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool isShuttingDown = false;
        private static object lockObject = new object();
        private static T instance;

        public static T Instance
        {
            get
            {
                if (isShuttingDown)
                {
                    Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null");
                    return null;
                }

                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType(typeof(T)) as T;

                        if (instance == null)
                        {
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).Name.ToString() + "(Singleton)";
                        }
                    }
                    return instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            isShuttingDown = true;
        }
    }
}
