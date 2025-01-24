using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraFollow : MonoBehaviour
{
   private Transform Player;

   Vector3 offset;//相机与人物之间的距离
  void Start()
  {
    Player = GameObject.Find("JohnLemon").transform;
    offset = transform.position-Player.position;
  }
   
   void Update()
  {
    transform.position = offset+Player.position;
  }
}
