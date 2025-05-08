using System;
using UnityEngine;
using UnityEngine.EventSystems;

// extention 만드는법 : 첫번째 매개변수에 this 붙이면 됨.

public static class Extension
{
    public static void AddUIEvent(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvnet(go, action, type);
    }
}
