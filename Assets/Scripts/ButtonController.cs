using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    // From video: https://youtu.be/cZzf1FQQFA0
    // YouTube: gamesplusjames
public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
            FMODUnity.RuntimeManager.PlayOneShot("event:/DrumHits/kick");
        }
        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}

