using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    // ex) Login씬이라면 - LoginScene 컴포넌트를 가진 @Scene오브젝트의 BaseScene반환
    public BaseScene CurrentScene { get { return GameObject.FindAnyObjectByType<BaseScene>(); } }

    public void LoadScene(Define.Scene type)
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }
}
