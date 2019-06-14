using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject TowerGo;//读取Cube身上的炮台
    public TowerData towerData;
    public GameObject buildEffect;

    private Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void BuildTower(GameObject towerPrefab)
    {
        TowerGo = GameObject.Instantiate(towerPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }

    public void UpGradeTower()
    {

    }
    public void DestroyTower()
    {
        Destroy(TowerGo);
        TowerGo = null;
        towerData = null;
    }



    void OnMouseEnter()
    {
        if (TowerGo == null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

}
