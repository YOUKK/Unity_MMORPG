using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    // 리스너 패턴
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool pressed = false;

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
                MouseAction.Invoke(Define.MouseEvent.Press);
                pressed = true;
            }
            else
            {
                if (pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                pressed = false;
            }
        }
    }
}
