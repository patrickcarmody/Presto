using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    //Fix frame rate issues on mobile builds
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
