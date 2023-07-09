using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR
    Application.targetFrameRate = 60;
#endif
    }

  public void Pause()
  {
    Time.timeScale = 0;
  }

  public void Resume()
  {
    Time.timeScale = 1;
  }

  public void Toggle()
  {
    if (Time.timeScale == 1)
      Pause();
    else Resume();
  }
}
