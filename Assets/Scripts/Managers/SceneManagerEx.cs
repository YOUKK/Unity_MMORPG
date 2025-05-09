using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    // ex) Login���̶�� - LoginScene ������Ʈ�� ���� @Scene������Ʈ�� BaseScene��ȯ
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
