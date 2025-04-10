using UnityEngine;

public class zmienne : MonoBehaviour
{
    public AudioSource AudioSource; 


    public void SetVolume(float volume)
    {
        AudioSource.volume = Mathf.Clamp(volume, 0.0f, 1.0f); 
    }



// to jest profesjonalnie zrobione (:

    public void volume_0()
    {
    AudioSource.volume = 0f;
    }
    public void volume_25()
    {
    AudioSource.volume = 0.25f;
    }

    public void volume_50()
    {
    AudioSource.volume = 0.5f;
    }

    public void volume_75()
    {
    AudioSource.volume = 0.75f;
    }
    public void volume_100()
    {
    AudioSource.volume = 1f;
    }







}