using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy1 : MonoBehaviour
{
    public float Speed = 10;
    public float hp = 100;
    private float totalHp;
    public Slider hpslider;
    private Transform[] position;
    private int index = 0;
    public GameObject enemyExplosionEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        position = RoadPoint.position;//调用路径点脚本的方法
        totalHp = hp;
        hpslider = GetComponentInChildren<Slider>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (index > position.Length - 1)
            return;
        transform.Translate((position[index].position-transform.position).normalized * Time.deltaTime * Speed);
        if (Vector3.Distance(position[index].position, transform.position)<0.2f)//判断物体是否到达路径点
        {
            index++;
        }
        if(index>position.Length-1)
        {
            ReachDestination();
        }
    }

    void ReachDestination()
    {
        GameContral.Instance.Failed();
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemyCreater.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)
    {
        if (hp <= 0) return;
        hp -= damage;
        hpslider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = GameObject.Instantiate(enemyExplosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }


}
