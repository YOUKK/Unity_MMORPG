using System;
using UnityEngine;
using UnityEngine.EventSystems;

// 유니티의 Input에서 제공하는 기능이라면 꼭 InputManager를 두지 않아도 됨.
// 근데 Input에서 제공하지 않는 입력의 종류라면 이런식으로 중앙에서 관리하는 게 좋음.
// 예를 들면 pressed 상태에서 drag 한다던가...이런거

public class InputManager
{
    // 리스너 패턴
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;
    float _pressedTime = 0;

    // PlayerController가 아무리 많아도 key input 검사는 여기서 한번만 체크된다!
    public void OnUpdate()
    {
        // UI를 클릭하는 경우 - 캐릭터 움직임X
        // 현재 마우스가 UI 위에 있다면 true 반환
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if(MouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                if(!_pressed)
                {
                    MouseAction.Invoke(Define.MouseEvent.PointerDown);
                    _pressedTime = Time.time;
                }
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;
            }
            else
            {
                if (_pressed)
                {
                    if(Time.time < _pressedTime + 0.2f)
                        MouseAction.Invoke(Define.MouseEvent.Click);

                    MouseAction.Invoke(Define.MouseEvent.PointerUp);
                }
                _pressed = false;
                _pressedTime = 0;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
