using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsever : MonoBehaviour
{
    public Transform Player;
    public GameEnding gameEnding;
    bool IsInRange = false;//检测是否进入触发点
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject==Player.gameObject)//扫描到了
      {
        Debug.Log("进入扫描范围");
        IsInRange = true;
      }
    }  

    private void OnTriggerExit(Collider other)//扫描到离开了
    {
      if(other.gameObject==Player.gameObject)
      {
        IsInRange = false;
      }
    }
    // Update is called once per frame
    void Update()
    {
        if(IsInRange==true)
        {
          //射线检测
          Vector3 dir = Player.position - transform.position+Vector3.up;
          Ray ray = new Ray(transform.position, dir);
          RaycastHit raycastHit;//扫到玩家时候的参数

          if(Physics.Raycast(ray,out raycastHit))
          {
            if(raycastHit.collider.transform==Player)
            {
              //宣告游戏失败,玩家被抓住了
              Debug.LogError("玩家被抓住了");
              gameEnding.Caught();
            }
          }
        }
    }
}
