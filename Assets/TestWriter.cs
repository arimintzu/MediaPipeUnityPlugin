using Mediapipe;
using Mediapipe.Unity;
using Mediapipe.Unity.FaceMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestWriter : MonoBehaviour
{
  public FaceMeshSolution solution;
  public TextMeshProUGUI text;

  private void Start()
  {
    solution.OnBlendshapeOutput += Test;
  }

  private void Test(ClassificationList result)
  {
    string format = string.Empty;

    var classification = result.Classification;
    if (classification?.Count > 0)
    {
      foreach (var item in classification)
      {
        if (AmIOnList((BlendShapeLocation)item.Index))
        {
          format += $"{((BlendShapeLocation)item.Index).ToString()} : {Mathf.Clamp(item.Score, 0f, 1f)}\n";
          //Debug.Log($"{((BlendShapeLocation)item.Index).ToString()} with score: {item.Score}");
        }
      }
      text.text = format;
    }
  }
    private bool AmIOnList(BlendShapeLocation location)
  {
    List<BlendShapeLocation> ToDisplay = new List<BlendShapeLocation>()
      { BlendShapeLocation.eyeBlinkLeft, BlendShapeLocation.eyeBlinkRight, BlendShapeLocation.browInnerUp,
    BlendShapeLocation.tongueOut,
    BlendShapeLocation.jawOpen,
    BlendShapeLocation.eyeLookInLeft,
    BlendShapeLocation.eyeLookInRight,
    BlendShapeLocation.eyeLookOutRight,
    BlendShapeLocation.eyeLookOutLeft,
    BlendShapeLocation.mouthClose,
    BlendShapeLocation.mouthSmileLeft,
    BlendShapeLocation.mouthSmileRight
    };

    return ToDisplay.Contains(location);
  }


}
