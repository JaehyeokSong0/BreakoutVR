using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    [HideInInspector] public int damage;

    private int _prevStageCnt;
    private void OnEnable() 
    {
        GameManager.m_Instance.activatedBulletCnt++;
        GameManager.m_Instance.m_bulletCnt--;
        rb = gameObject.GetComponent<Rigidbody>();
        damage = 1;
        _prevStageCnt = GameManager.m_Instance.m_stageCnt;
    }

    private void Update() 
    {
        lastFrameVelocity = rb.velocity;
        if(_prevStageCnt != GameManager.m_Instance.m_stageCnt)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision other) 
    {
        // Players and guns do not affect collision.
        if((other.gameObject.layer != 6) && (other.gameObject.layer != 7))
            Bounce(other.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }

    private void OnDestroy() 
    {
        GameManager.m_Instance.activatedBulletCnt--;
    }
}
