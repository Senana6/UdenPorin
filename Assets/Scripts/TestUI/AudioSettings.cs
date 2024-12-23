using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider masterVolumeSlider;//�S�̉���
    public Slider bgmVolumeSlider;//BGM����
    public Slider seVolumeSlider;//SE����

    private AudioSource bgmSource;
    private AudioSource seSource;
    // Start is called before the first frame update
    void Start()
    {
        //�����l�̐ݒ�
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1.0f);
        seVolumeSlider.value = PlayerPrefs.GetFloat("SEVolume", 1.0f);

        //�I�[�f�B�I�\�[�X�̎擾
        bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        seSource = GameObject.Find("SE").GetComponent<AudioSource>();

        ApplyVolumeSettings();
    }

    public void ApplyVolumeSettings()
    {
        float masterVolume = masterVolumeSlider.value;
        float bgmVolume = bgmVolumeSlider.value;
        float seVolume = seVolumeSlider.value;

        //���ʂ�K�p
        AudioListener.volume = masterVolumeSlider.value;
        if(bgmSource != null)bgmSource.volume = bgmVolume;
        if(seSource != null)seSource.volume = seVolume;

        //�ݒ��ۑ�
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("BGMVolume", bgmVolumeSlider.value);
        PlayerPrefs.SetFloat("SEVolume", seVolumeSlider.value);
        PlayerPrefs.Save();
    }
}
