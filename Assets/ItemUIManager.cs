using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemUIManager : MonoBehaviour
{
    private string[] items = {"총알 데미지\n+1","총알 데미지\n+2","총알 비용\n-1","총알 비용\n-2","총알 크기\n+1","총알 크기\n+2"};
    public TMP_Text leftItemText;
    public TMP_Text rightItemText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        int _left, _right;
        _left = Random.Range(0,6);
        _right = Random.Range(0,6);

        leftItemText.text = "[" + _left + "]" + items[_left];
        rightItemText.text = "[" + _right + "]" +items[_right];
    }

    public void OnButtonClick()
    {
        
        GameObject _curr = EventSystem.current.currentSelectedGameObject;
        int _itemNum = _curr.GetComponentInChildren<TextMeshProUGUI>().text[1] - 48;
        
        switch(_itemNum)
        {
        case 0:
            GameManager.m_Instance.ammo.Enqueue(1);
            break;
        case 1:
            GameManager.m_Instance.ammo.Enqueue(1);
            GameManager.m_Instance.ammo.Enqueue(1);
            break;
        case 2:
            GameManager.m_Instance.ammo.Enqueue(2);
            break;
        case 3:
            GameManager.m_Instance.ammo.Enqueue(2);
            GameManager.m_Instance.ammo.Enqueue(2);
            break;
        case 4:
            GameManager.m_Instance.ammo.Enqueue(3);
            break;
        case 5:
            GameManager.m_Instance.ammo.Enqueue(3);
            GameManager.m_Instance.ammo.Enqueue(3);
            break;
        }

    }

}
