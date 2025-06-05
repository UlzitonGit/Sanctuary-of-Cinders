using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _miningAudioClips;
    [SerializeField] private AudioClip[] _woodAudioClips;
    [SerializeField] private AudioClip[] _blackAudioClips;
    [SerializeField] private AudioClip _sellAudioClips;
    [SerializeField] private AudioClip _semiReadySword;
    [SerializeField] private AudioClip _ReadySword;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _looseSound;
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
    public void PlaySell()
    {
        _audioSource.PlayOneShot(_sellAudioClips);
    }
    public void PlaySemiReady()
    {
        _audioSource.PlayOneShot(_semiReadySword);
    }
    public void PlayReady()
    {
        _audioSource.PlayOneShot(_ReadySword);
    }
    public void PlayWin()
    {
        _audioSource.PlayOneShot(_winSound);
    }
    public void PlayCant()
    {
        _audioSource.PlayOneShot(_looseSound);
    }
}
