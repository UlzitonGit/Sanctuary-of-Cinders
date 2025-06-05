using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] _miningAudioClips;
    [SerializeField] AudioClip[] _woodAudioClips;
    [SerializeField] AudioClip[] _blackAudioClips;
    [SerializeField] AudioSource _audioSource;

    public void PlayMining()
    {
        _audioSource.PlayOneShot(_miningAudioClips[Random.Range(0, _miningAudioClips.Length)]);
    }
    public void PlayWood()
    {
        _audioSource.PlayOneShot(_woodAudioClips[Random.Range(0, _woodAudioClips.Length)]);
    }
    public void PlayBlack()
    {
        _audioSource.PlayOneShot(_blackAudioClips[Random.Range(0, _blackAudioClips.Length)]);
    }
}
