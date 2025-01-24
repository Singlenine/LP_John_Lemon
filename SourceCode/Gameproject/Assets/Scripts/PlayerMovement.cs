using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnspeed = 20f;   //定义旋转速度
 
    Animator m_Animator;
    Rigidbody m_Rigidbody; //定义游戏人物上的组件

    Vector3 m_Movement;//游戏人物移动的矢量
    Quaternion m_Quaternion=Quaternion.identity;//定义人物旋转的角度

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        //获取人物上的刚体、动画控制机制组件
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");//键盘输入水平移动
        float vertical = Input.GetAxis("Vertical");//键盘输入数值移动
        m_Movement.Set(horizontal, 0f, vertical);//设置游戏人物移动方向
        m_Movement.Normalize();//速度归一化

        bool hasHorizontalInput = !Mathf.Approximately(horizontal,0f); //定义移动的bool值
        bool hasverticalInput = !Mathf.Approximately(vertical, 0f);

        //控制动画播放
        bool iswalking = hasHorizontalInput || hasverticalInput;
        m_Animator.SetBool("IsWalking", iswalking);

        //旋转的过渡
        Vector3 desirForwad = Vector3.RotateTowards(transform.forward, m_Movement, turnspeed * Time.deltaTime, 0f);
        m_Quaternion = Quaternion.LookRotation(desirForwad);
    }

    //游戏人物的旋转和过渡
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Quaternion);
    }
   
}

