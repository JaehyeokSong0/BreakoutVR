using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameResultUIManager : MonoBehaviour
{
    public GameObject m_winText;
    public GameObject m_loseText;
    public void PlayerWin()
    {
        gameObject.SetActive(true);
        m_winText.SetActive(true);
        m_loseText.SetActive(false);
    }
    public void PlayerLose()
    {
        gameObject.SetActive(true);
        m_winText.SetActive(false);
        m_loseText.SetActive(true);
    }
}
