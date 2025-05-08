using System.Collections.Generic;
using UnityEditor.Embree;
using UnityEngine;

// UI 팝업 키고 끄는 기능 요청 => Canvas의 Sort Order를 관리
public class UIManager
{
    int _order = 10; // Canvas의 Sort Order

    // 유니티는 컴포넌트 패턴임
    // UI_Button.cs(UI_Popup 상속받음) 컴포넌트를 가지고 있는 오브젝트가 popup이란 걸 알 수 있음
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; // 캔버스가 중첩해 있을 때, 부모의 sort order에 상관없이 자신의 sort order 가지기

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else // popupStack에 안 들어가는 일반 UI
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowScenepUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T sceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = sceneUI;
        go.transform.SetParent(Root.transform);


        // 여기에서 popup++ 해버리면 이미 씬에 UI는 sort order 관리가 안 된다. 그래서 UI_Popup.cs에서 관리!

        return sceneUI;
    }

    // 앞에있는 T - UI/Popup 폴더 스크립트
    // 뒤에있는 T - UI popup의 이름. 만약 매개변수가 null이면 T를 이름으로 쓴다.
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup// UI popup 프리팹의 name
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        go.transform.SetParent(Root.transform);


        // 여기에서 popup++ 해버리면 이미 씬에 UI는 sort order 관리가 안 된다. 그래서 UI_Popup.cs에서 관리!
        
        return popup;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed!");
            return;
        }

        ClosePopupUI();
    }

    // popupStack에 있는 걸 순차적으로 끄기
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null; // 삭제되었기에 접근하면 안됨!! 혹시나 해서 null 할당해둠

        _order--;
    }

    public void CloseAllPopUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
}
