using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<GameObject> enemys = new List<GameObject>();
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemys")
        {
            enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "enemys")
        {
            enemys.Remove(col.gameObject);
        }
    }

    public float attackRateTime = 1;
    private float timer = 0;

    public GameObject bulletPrefab;
    public Transform fire;
    public Transform head;

    public bool useLaser = false;
    public float damageRate = 30;
    public LineRenderer laserRenderer;
    public GameObject laserEffect;

    void Start()
    {
        timer = attackRateTime;
    }

    void Update()
    {
        if (enemys.Count > 0 && enemys[0] != null)
        {
                Vector3 targetPosition = enemys[0].transform.position;
                targetPosition.y = head.position.y;
                head.LookAt(targetPosition);
        }

        if(useLaser == false)
        {
            timer += Time.deltaTime;
            if (enemys.Count>0&&timer >= attackRateTime)
            {
                timer = 0;
                Attack();
            }
        }
        else if(enemys.Count>0)
        {
            if (laserRenderer.enabled == false)
                laserRenderer.enabled = true;
            laserEffect.SetActive(true);
            if (enemys[0] == null)
            {
                UpdataEnemys();
            }
            if (enemys.Count > 0)
            {
                laserRenderer.SetPositions(new Vector3[] { fire.position, enemys[0].transform.position });
                enemys[0].GetComponent<Enemy1>().TakeDamage(damageRate * Time.deltaTime);
                laserEffect.transform.position = enemys[0].transform.position;
                Vector3 pos = transform.position;
                pos.y = enemys[0].transform.position.y;
                laserEffect.transform.LookAt(pos);
            }
        }
        else
        {
            laserRenderer.enabled = false;
            laserEffect.SetActive(false);
        }
    }
    void Attack()
    {
        if(enemys[0] == null)
        {
            UpdataEnemys();
        }
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, fire.position, fire.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = attackRateTime;
        }
    }

    void UpdataEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for(int index = 0; index < enemys.Count; index++)
        {
            if(enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }
        for(int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i]-i);
        }

    }

}