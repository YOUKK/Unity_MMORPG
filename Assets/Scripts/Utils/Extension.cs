using System;
using UnityEngine;
using UnityEngine.EventSystems;

// extention ����¹� : ù��° �Ű������� this ���̸� ��.

public static class Extension
{
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvnet(go, action, type);
    }
}
