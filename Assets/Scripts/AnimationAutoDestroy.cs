using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAutoDestroy : MonoBehaviour
{
    public float delay = 0f;

    // Use this for initialization
    void Start()
    {
        float animTime = GetComponent<Animator>()
            .GetCurrentAnimatorStateInfo(0).length;

        Destroy(gameObject, animTime + delay);
    }
}
