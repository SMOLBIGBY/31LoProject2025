using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public AudioSource audioSource;

    [SerializeField] private Slider _slider;

    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume", 0.25f); // default to 1
        _slider.value = audioSource.volume;


        _slider.onValueChanged.AddListener(SetVolume); // respond to slider changes
    }

    void Update()
    {
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
        PlayerPrefs.Save();
        audioSource.volume = _slider.value;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0.0f, 1.0f);
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
        PlayerPrefs.Save();
    }





    // to jest profesjonalnie zrobione (:

    public void volume_0()
    {
        _slider.value = 0f;
    }
    public void volume_25()
    {
        _slider.value = 0.25f;
    }

    public void volume_50()
    {
        _slider.value = 0.5f;
    }

    public void volume_75()
    {
        _slider.value = 0.75f;
    }
    public void volume_100()
    {
        _slider.value = 1f;
    }







}