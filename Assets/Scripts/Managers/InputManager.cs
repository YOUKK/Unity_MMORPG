using System;
using UnityEngine;

public class InputManager
{
    // 리스너 패턴
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool pressed = false;

    // PlayerController가 아무리 많아도 key input 검사는 여기서 한번만 체크된다!
    public void OnUpdate()
    {
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
