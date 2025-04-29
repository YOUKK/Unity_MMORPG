using UnityEngine;

public class Managers : MonoBehaviour
{    
    static Managers instance;
    static Managers Instance { get{ Init(); return instance; } }

    InputManager input = new InputManager();
    ResourceManager resource = new ResourceManager();
    public static InputManager Input { get { return Instance.input; } }
    public static ResourceManager Resource { get { return Instance.resource; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        input.OnUpdate();
    }

    static void Init()
    {
        if(instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            instance = go.GetComponent<Managers>();
        }
    }
}
