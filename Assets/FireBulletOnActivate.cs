using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireBulletOnActivate : MonoBehaviour
{
    // Item management 
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if(GameManager.m_Instance.m_bulletCnt > 0)
        {
            GameObject spawnedBullet = Instantiate(bullet);

            spawnedBullet.transform.position = spawnPoint.position;
            if(GameManager.m_Instance.ammo.Count > 0)
            {
                int _num = GameManager.m_Instance.ammo.Dequeue();
                switch(_num)
                {
                    case 1: // 총알 데미지
                        spawnedBullet.GetComponent<BallManager>().damage++;
                        spawnedBullet.GetComponent<MeshRenderer>().material.color = Color.red;
                    break;
                    case 2: // 총알 개수
                        GameManager.m_Instance.m_bulletCnt++;
                    break;
                    case 3: // 총알 크기
                        spawnedBullet.transform.localScale += new Vector3(0.3f,0.3f,0.3f);
                        spawnedBullet.GetComponent<MeshRenderer>().material.color = Color.black;
                    break;
                }
            }
            
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            Destroy(spawnedBullet, 10);
        }
    }
}
