using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GameObject.FindWithTag("YourSliderTag").GetComponent<Slider>(); 
        LoadVolumeSettings(); 
    }
    public void OnVolumeChanged(float value)
    {
        SoundManager.Instance.SetVolume(value); 

        SaveVolumeSettings(); 
    }

    private void SaveVolumeSettings()
    {
        SoundManager.Instance.SaveVolumeSettings(_slider.value); 
    }

    private void LoadVolumeSettings()
    {
        float savedVolume = SoundManager.Instance.LoadVolumeSettings(); 
        _slider.value = savedVolume; 
    }
}

