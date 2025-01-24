using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WaypointPatrol : MonoBehaviour
{
    //导航组件
    public NavMeshAgent navMeshAgent;
    //幽灵移动的目标点数组
    public Transform[] waypoints;
    //幽灵的当前目标点的索引
    int m_currentpointIndex=0;
    
    // Start is called before the first frame update
    void Start()
    {
      navMeshAgent = GetComponent<NavMeshAgent>();
      navMeshAgent.SetDestination(waypoints[m_currentpointIndex].position);    
    }

    // Update is called once per frame
    void Update()
    {
        //如果幽灵当前距离目标点的位置已经小于误差值。则进行目标点和目标点索引的更新
        if (navMeshAgent.remainingDistance<navMeshAgent.stoppingDistance) 
        {
            m_currentpointIndex=(m_currentpointIndex+1)%waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_currentpointIndex].position);
        }

    }
}
