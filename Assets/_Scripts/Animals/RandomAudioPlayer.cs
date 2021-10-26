using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    [System.Serializable]
    public class SoundBank
    {
        public string name;
        public AudioClip[] clips;
    }

    public SoundBank soundBank = new SoundBank();//上記クラスのインスタンス生成
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(RoopRandomPlay());
    }

    private IEnumerator RoopRandomPlay()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            PlayRandomClip();
        }

    }

    public void PlayRandomClip()
    {
        var clip = soundBank.clips[Random.Range(0, soundBank.clips.Length)];

        //if (clip = null)
        //{
        //    return;
        //}

        m_AudioSource.clip = clip;//assign chosen clip to audiosource
        m_AudioSource.Play();
    }

}
