using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 50;
    public float Speed = 20;
    public GameObject explosionEffectPrefab;
    private float distanceTarget = 1;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(target == null)
        {
            Die();
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        Vector3 dir = target.position - transform.position;
        if (dir.magnitude <= distanceTarget)
        {
            target.GetComponent<Enemy1>().TakeDamage(damage);
            Die();
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);
    }



}
