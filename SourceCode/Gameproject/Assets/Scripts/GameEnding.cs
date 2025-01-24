using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnding : MonoBehaviour
{
  public float fadeDuration = 1f;//淡入淡出
  public float displayDuration = 1f;//显示
  public GameObject Player;
  public CanvasGroup ExitBK;//胜利背景
  public CanvasGroup FailBK;//失败背景
  bool IsExit=false;//胜利bool
  bool IsFail=false;//失败bool
  public float timer=0f;
  public AudioSource winaudio;//音频组件
  public AudioSource failaudio;

  bool IsPlay=false;//控制音效只播放一次
  private void OnTriggerEnter(Collider other)
  {
      if (other.gameObject == Player)
      {
        IsExit = true;
      }
  }

  public void Caught()
  {
    IsFail=true;
  }
    // Update is called once per frame
    void Update()
    {
        if (IsExit)
        {
          Debug.Log("执行ExitBK");
          EndLevel(ExitBK,false,winaudio);
        }
        else if (IsFail)
        {
          Debug.Log("执行FailBK");
          EndLevel(FailBK,true,failaudio);
        }
    }

    //游戏或失败的执行方法
    void EndLevel(CanvasGroup igCanvasGroup,bool doRestart,AudioSource playaudio)//前参数是是否胜利，第二个参数是是否重启
    {
      //音效播放胜利或者失败
      if(!IsPlay)
      {
        playaudio.Play();
        IsPlay=true;//防止重复执行
      }
      timer += Time.deltaTime;//碰到触发器时开始计时
      igCanvasGroup.alpha = timer/fadeDuration;

      if(timer>fadeDuration+displayDuration)
      {
        //游戏失败重启游戏
        if(doRestart)
        {
          SceneManager.LoadScene("Main");
        }//游戏成功就退出
        else if(!doRestart)
        {
          Application.Quit();
        }
      }
    }
}
