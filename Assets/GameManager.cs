using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance = null;

    [HideInInspector] public int m_stageCnt;
    [HideInInspector] public int m_bulletCnt;
    [HideInInspector] public GameObject m_block;


    public GameObject[] blocks;
    [HideInInspector] public int[] bulletCnts;
    private int[] blockCnts = {10,12,18,16,0}; // Sum of the blockHP of each blocks : 14 ,24, 27, 29
    [HideInInspector] public int activatedBulletCnt;
    [HideInInspector] public int activatedBlockCnt;

    public GameObject GameResultUI;
    public GameObject ItemUI;

    [HideInInspector] public Queue<int> ammo = new Queue<int>();

    void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
            // DontDestroyOnLoad(this.gameObject);
        }

        m_stageCnt = 0;
        m_block = null;
        activatedBlockCnt = 0;
        bulletCnts = new int[] {20,25,30,35,0};
    }

    // Update is called once per frame
    void Update()
    {
        switch(calcStageResult())
        {
            case 1: // Stage cleared
                if(m_stageCnt < 4)
                    setStage(m_stageCnt+1);
                else
                    GameResultUI.GetComponent<GameResultUIManager>().PlayerWin();
                break;
            case -1: // Stage failed
                GameResultUI.GetComponent<GameResultUIManager>().PlayerLose();
                break;
            case 0: // Stage goes on
                break;
        }
    }

    
    public void InitGame()
    {
        if(m_block != null)
            Destroy(m_block);
        setStage(1);
    }

    public void setStage(int stageNum)
    {
        ItemUI.SetActive(true);
        m_stageCnt = stageNum;
        m_bulletCnt = bulletCnts[stageNum - 1];
        activatedBlockCnt = blockCnts[stageNum - 1];
        activatedBulletCnt = 0;
        m_block = Instantiate(blocks[stageNum-1]);
    }

    public int calcStageResult()
    {
        if(m_stageCnt > 0)
        {
            if(activatedBlockCnt <= 0) // All block destroyed
                return 1; // Stage cleared
            if(m_bulletCnt <= 0) // No left bullets
            {
                if(activatedBulletCnt != 0) // There are left activated bullets
                    return 0; // Stage goes on
                else
                    return -1; // Stage failed
            }
            else 
                return 0; 
        }
        else
            return 0;
    }
}
