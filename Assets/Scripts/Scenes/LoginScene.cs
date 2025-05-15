using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LoginScene : BaseScene
{
    // 오브젝트가 비활성화 되어있어도 호출되도록 awake에 작성
    void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Login;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear!");
    }
}
