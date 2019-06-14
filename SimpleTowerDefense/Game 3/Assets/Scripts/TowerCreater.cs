using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TowerCreater : MonoBehaviour
{
    public TowerData MachineGunTowerData;
    public TowerData LaserTowerData;
    public TowerData MissileTowerData;
    private float sell = 0;

    private TowerData SelectedTowerData; //当前选择的炮台

    public Animator moneyAnimator;
    public Text moneyText;
    public int money = 300;

    void UpdateMoney(int change=0)
    {
        money += change;
        moneyText.text = "$" + money;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject()==false)//鼠标是否点击在UI界面上
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider =  Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));
                if(isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    //将鼠标点击转换为射线，检测其与Cube的碰撞事件,从而得到所点击的Cube
                    if(SelectedTowerData != null && mapCube.TowerGo == null)
                    {
                        if(money >= SelectedTowerData.cost)
                        {
                            UpdateMoney(-SelectedTowerData.cost);
                            mapCube.BuildTower(SelectedTowerData.TowerPrefab);
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if(mapCube.TowerGo != null)
                    {
                        if(sell == 1)
                        {
                            hit.collider.GetComponent<MapCube>().DestroyTower();
                        }
                    }
                }

            }
        }
     

    }

    public void OnMachineGunSelected(bool isOn)
    {
        if(isOn)
        {
            SelectedTowerData = MachineGunTowerData;
        }
    }
    public void OnLaserSelected(bool isOn)
    {
        if(isOn)
        {
            SelectedTowerData = LaserTowerData;
        }
    }
    public void OnMissileSelected(bool isOn)
    {
        if(isOn)
        {
            SelectedTowerData = MissileTowerData;
        }
    }
    public void OnSell(bool isOn)
    {
        if(isOn)
        {
            sell = 1;
        }
    }
}
