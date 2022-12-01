using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameInfoUIManager : MonoBehaviour
{
    public TMP_Text m_stageCntText;
    public TMP_Text m_bulletCntText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int _stageCnt = GameManager.m_Instance.m_stageCnt;
        m_stageCntText.text = "Current Stage : " + _stageCnt;
        if(_stageCnt > 0)
        {
            m_bulletCntText.text = "BULLET : " + GameManager.m_Instance.m_bulletCnt + " / " + GameManager.m_Instance.bulletCnts[_stageCnt - 1];
        }

    }
}
