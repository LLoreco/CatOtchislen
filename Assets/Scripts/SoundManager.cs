using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        if (_audioClips.Length > 0)
        {
            _audioSource.clip = _audioClips[0];
            _audioSource.Play();
        }
    }
}