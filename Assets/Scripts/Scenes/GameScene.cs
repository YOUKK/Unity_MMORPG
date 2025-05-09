using UnityEngine;

public class GameScene : BaseScene
{
    // 오브젝트가 비활성화 되어있어도 호출되도록 awake에 작성
    void Awake()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowScenepUI<UI_Inven>();
    }

    public override void Clear()
    {
        
    }
}
