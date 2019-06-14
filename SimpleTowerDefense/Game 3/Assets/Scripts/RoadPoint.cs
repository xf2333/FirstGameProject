using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPoint : MonoBehaviour
{
    public static Transform[] position;//定义数组存放路径点
    // Start is called before the first frame update
    void Awake()
    {
        position = new Transform[transform.childCount];//数组大小即路径点（子）数量
        for (int i = 0; i < position.Length; i++)
        {
            position[i] = transform.GetChild(i);//根据孩子的索引获得孩子
        }
    }
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
