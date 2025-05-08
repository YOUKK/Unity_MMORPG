using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    [SerializeField]
    TextMeshProUGUI _text;

    // Button 오브젝트의 이름들을 enum으로 저장
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

        Bind<Button>(typeof(Buttons)); // enum은 Buttons인데, Button 컴포넌트를 가진 오브젝트에 매핑해주세요라는 의미
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        // 인스펙터 버튼 이벤트 드래그&드롭을 코드 한 줄로 처리하기~
        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject; // ItemIcon 게임 오브젝트
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
