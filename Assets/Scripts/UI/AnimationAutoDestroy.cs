using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAutoDestroy : MonoBehaviour
{
    // Destroys GameObject after animation finishes

    public float delay = 0f;

    void Start()
    {
        float animTime = GetComponent<Animator>()
            .GetCurrentAnimatorStateInfo(0).length;

        Destroy(gameObject, animTime + delay);
    }
}
