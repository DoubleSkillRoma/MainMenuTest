using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("����������� ��������� �������")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _volumeParameterName = "Volume";
    private float _currentValue;
    private readonly float _firstRunValue = 20.0f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadVolumeSettings();
    }

    public void SetVolume(float volume)
    {
        _currentValue = volume;
        _audioMixer.SetFloat(_volumeParameterName, volume);
    }

    public void SaveVolumeSettings(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public float LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            _currentValue = savedVolume;
            _audioMixer.SetFloat(_volumeParameterName, _currentValue);
            return savedVolume;
        }
        else
        {
            // ���� ���� "MusicVolume" �� ����������, ��������� ��������� �� �������� -20.0f
            _currentValue = _firstRunValue;
            _audioMixer.SetFloat(_volumeParameterName, _currentValue);
            return _currentValue;
        }
    }
}