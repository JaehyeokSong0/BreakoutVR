using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private int blockHP;
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        string matName = gameObject.GetComponent<MeshRenderer>().material.name;
        blockHP = matName[matName.Length - 12] - 48;
    }

    // Update is called once per frame
    void Update()
    {
        if(blockHP < 1)
        {
            Destroy(gameObject);
            GameManager.m_Instance.activatedBlockCnt--;
        }
        UpdateMaterial();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Bullet")
            blockHP = blockHP - other.gameObject.GetComponent<BallManager>().damage;
    }

    private void UpdateMaterial()
    {
        if(blockHP >= 1)
            gameObject.GetComponent<MeshRenderer>().material = materials[blockHP -1];
    }
}
