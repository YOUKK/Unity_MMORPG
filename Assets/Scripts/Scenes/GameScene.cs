using System.Collections;
using UnityEngine;

public class GameScene : BaseScene
{
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
