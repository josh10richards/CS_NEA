using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{

    [SerializeField] private TMP_Text label;
    private void Awake()
    {
        Hide();
    }

    // Update is called once per frame
    public void Show(string text)
    {
        label.text = text;
        label.gameObject.SetActive(true);
    }

    public void Hide()
    {
        label.gameObject.SetActive(false);
    }




}
