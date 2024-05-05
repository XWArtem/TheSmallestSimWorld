using UnityEngine;
using UnityEngine.UI;

public class ButtonTapSound : MonoBehaviour
{
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayTapSound);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(PlayTapSound);
    }

    private void PlayTapSound()
    {

    }
}
