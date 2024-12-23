using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public void OnGoButtonClicked()
    {
        //�X�e�[�W�i�Q�[����ʂɈړ�����j
        SceneManager.LoadScene("GameScene");
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void OnOptionButtoenClicked()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
