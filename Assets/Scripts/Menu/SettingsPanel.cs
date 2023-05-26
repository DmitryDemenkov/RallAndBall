using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public bool IsOpened { get; set; } = false;

    [SerializeField] private Sensitivity _sensitivity;

    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
    }

    public void Open()
    {
        if (!IsOpened && !_animation.isPlaying)
        {
            StartCoroutine(PlayAnimationCoroutine("OpenSettings"));
        }
    }

    public void Close()
    {
        if (IsOpened && !_animation.isPlaying)
        {
            StartCoroutine(PlayAnimationCoroutine("CloseSettings"));
        }
    }

    private IEnumerator PlayAnimationCoroutine(string clip)
    {
        _animation.Play(clip);
        yield return new WaitWhile(() => _animation.isPlaying);
        IsOpened = !IsOpened;
    }

    public void Save()
    {
        _sensitivity.Save();
    }
}
