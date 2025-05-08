using System.Collections.Generic;
using UnityEditor.Embree;
using UnityEngine;

// UI �˾� Ű�� ���� ��� ��û => Canvas�� Sort Order�� ����
public class UIManager
{
    int _order = 10; // Canvas�� Sort Order

    // ����Ƽ�� ������Ʈ ������
    // UI_Button.cs(UI_Popup ��ӹ���) ������Ʈ�� ������ �ִ� ������Ʈ�� popup�̶� �� �� �� ����
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
        canvas.overrideSorting = true; // ĵ������ ��ø�� ���� ��, �θ��� sort order�� ������� �ڽ��� sort order ������

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else // popupStack�� �� ���� �Ϲ� UI
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


        // ���⿡�� popup++ �ع����� �̹� ���� UI�� sort order ������ �� �ȴ�. �׷��� UI_Popup.cs���� ����!

        return sceneUI;
    }

    // �տ��ִ� T - UI/Popup ���� ��ũ��Ʈ
    // �ڿ��ִ� T - UI popup�� �̸�. ���� �Ű������� null�̸� T�� �̸����� ����.
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup// UI popup �������� name
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        go.transform.SetParent(Root.transform);


        // ���⿡�� popup++ �ع����� �̹� ���� UI�� sort order ������ �� �ȴ�. �׷��� UI_Popup.cs���� ����!
        
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

    // popupStack�� �ִ� �� ���������� ����
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null; // �����Ǿ��⿡ �����ϸ� �ȵ�!! Ȥ�ó� �ؼ� null �Ҵ��ص�

        _order--;
    }

    public void CloseAllPopUI()
    {
        while (_popupStack.Count > 0)
            ClosePopupUI();
    }
}
