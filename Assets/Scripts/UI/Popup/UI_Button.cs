using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    [SerializeField]
    TextMeshProUGUI _text;

    // Button ������Ʈ�� �̸����� enum���� ����
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons)); // enum�� Buttons�ε�, Button ������Ʈ�� ���� ������Ʈ�� �������ּ����� �ǹ�
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        // �ν����� ��ư �̺�Ʈ �巡��&����� �ڵ� �� �ٷ� ó���ϱ�~
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject; // ItemIcon ���� ������Ʈ
        AddUIEvnet(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
    }


    int score = 0;

    public void OnButtonClicked(PointerEventData data)
    {
        score++;
        //text.text = $"Point : {score}";
        GetText((int)Texts.ScoreText).text = $"Point : {score}";
    }
}
