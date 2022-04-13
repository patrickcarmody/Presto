using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SliderPlayer : MonoBehaviour
{
    private float tempo;
    public bool playOnEnable;

    [FMODUnity.EventRef]
    public FMOD.Studio.EventInstance tempoSlider;

    // Start is called before the first frame update
    void Start()
    {
        tempoSlider = FMODUnity.RuntimeManager.CreateInstance("event:/Lessons/Rhythm3/TempoSlider");
        tempo = 90;
    }

    void Update()
    {
        tempoSlider.setParameterByName("tempo", tempo);
    }

    private void OnEnable()
    {
        if (playOnEnable)
        {
            PlayAudio();
        }
    }

    private void OnDisable()
    {
        StopAudio();
    }

    public void ChangeTempo(float newTempo)
    {
        tempo = newTempo*10;
    }

    public void PlayAudio()
    {
        tempoSlider.start();
    }

    public void StopAudio()
    {
        tempoSlider.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}