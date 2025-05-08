using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    // ������ ����
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool pressed = false;

    // PlayerController�� �ƹ��� ���Ƶ� key input �˻�� ���⼭ �ѹ��� üũ�ȴ�!
    public void OnUpdate()
    {
        // UI�� Ŭ���ϴ� ��� - ĳ���� ������X
        // ���� ���콺�� UI ���� �ִٸ� true ��ȯ
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
