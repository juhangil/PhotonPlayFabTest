using UnityEngine;

//public to be accessible by Unity engine
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T I
    {
        get
        {
            CreateInstance();
            return _instance;
        }
    }

    public static void CreateInstance()
    {
        if (_instance == null)
        {
            //find existing instance
            _instance = FindObjectOfType<T>();
            if (_instance == null)
            {
                //create new instance
                var go = new GameObject(typeof(T).Name);
                _instance = go.AddComponent<T>();
            }
            //initialize instance if necessary
            if (!_instance.initialized)
            {
                _instance.Initialize();
                _instance.initialized = true;
            }
        }
    }

    public virtual void Awake()
    {
        //check if instance already exists when reloading original scene
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
        }
    }

    protected bool initialized;

    protected virtual void Initialize() { }
}