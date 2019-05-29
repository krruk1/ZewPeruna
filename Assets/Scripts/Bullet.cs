using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;
    public float explosionRadious = 0f;

    void Update()
    {
        if( target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = Time.deltaTime * speed;

        if( dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        Debug.Log("hit");
        GameObject effectIns = (GameObject)Instantiate(impactEffect , transform.position , transform.rotation );
        Destroy(effectIns, 5f);

        if(explosionRadious > 0f)
        {
            Explode();
        }

        else
        {
            Damage(target);
        }
        Destroy(gameObject);
        
    }

    public void Damage(Transform enemy)
    {
        enemy.GetComponent<Enemy>().Hit(50);
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadious);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    public void Seek(Transform _target)
    {
        Debug.Log("go");
        target = _target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadious);
    }
}
