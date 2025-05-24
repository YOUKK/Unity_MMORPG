using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        if(typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('.');
            if (index >= 0)
                name = name.Substring(index + 1);

            // 1. 풀에 이미 있는 original이라면 반환
            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if(original == null )
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        // 2. Poolable 오브젝트라면 풀에서 가져오기
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        // Poolable 오브젝트가 아니었다면
        GameObject go = Object.Instantiate(original, parent);
        int index = go.name.IndexOf("(Clone)");
        if(index > 0)
            go.name = go.name.Substring(0, index);

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        // 3. Poolable 오브젝트라면 풀에 반환
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        // Poolable 오브젝트가 아니었다면
        Object.Destroy(go);
    }
}
