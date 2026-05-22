using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class EvolutionButton : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public Image img;
    public Button btn;

    public void Init(string name, Sprite sprite, UnityAction callback)
    {
        txt.text = name;
        img.sprite = sprite;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(callback);
    }

    public void SetInteractable(bool state)
    {
        btn.interactable = state;
    }
}