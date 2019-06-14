using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour
{
    public static int CountEnemyAlive = 0;
    public Wave[] waves;
    public Transform START;
    public float waverate = 0.2f;
    private Coroutine coroutine;

    void Start()
    {
        coroutine = StartCoroutine(CreateEnemy());
    }
    public void Stop()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator CreateEnemy()
    {
        foreach (Wave wave in waves)
        {
            for(int i = 0;i < wave.count; i++)
            {
                GameObject.Instantiate(wave.EnemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;
                if (i!=wave.count-1)
                yield return new WaitForSeconds(wave.rate);
            }
            while(CountEnemyAlive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waverate);
        }
        while (CountEnemyAlive > 0)
        {
            yield return 0;
        }
        GameContral.Instance.Win();
    }
}
