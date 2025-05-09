using UnityEngine;

public class GameScene : BaseScene
{
    // ������Ʈ�� ��Ȱ��ȭ �Ǿ��־ ȣ��ǵ��� awake�� �ۼ�
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
