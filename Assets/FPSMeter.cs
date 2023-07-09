using UnityEngine;
using TMPro;

public class FPSMeter : MonoBehaviour
{
  public TextMeshProUGUI fpsText;

  private float updateInterval = 0.5f;  // Interval between FPS updates
  private float accum = 0f;            // FPS accumulated over the interval
  private int frames = 0;              // Frames drawn over the interval
  private float timeLeft;              // Time left for the current interval

  private void Start()
  {
    if (fpsText == null)
    {
      Debug.LogWarning("FPSCounter: TextMeshProUGUI component is not assigned!");
      enabled = false;
      return;
    }

    timeLeft = updateInterval;
  }

  private void Update()
  {
    timeLeft -= Time.deltaTime;
    accum += Time.timeScale / Time.deltaTime;
    frames++;

    // Interval ended - update the FPS text
    if (timeLeft <= 0)
    {
      float fps = accum / frames;
      fpsText.text = Mathf.RoundToInt(fps).ToString();

      timeLeft = updateInterval;
      accum = 0f;
      frames = 0;
    }
  }
}
