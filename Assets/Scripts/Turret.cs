using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    

    [Header("Attributes")]
    public float range = 15;
    public float turnSpeed = 5f;
    public float firespeed = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    private Transform target;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
            return;
        

        Vector3 dir = transform.position - target.transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation , lookRotation , Time.deltaTime * turnSpeed ).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if( fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / firespeed;
        }

        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if( bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
