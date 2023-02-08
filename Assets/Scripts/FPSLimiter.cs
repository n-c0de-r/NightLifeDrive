using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake () {
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 60;
 }
}
