using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public TextMeshProUGUI titleTxt;
    public Image pokemonSprite;
    public Button pokemonBtn;

    public void Init(PokemonSO pokemonSO)
    {
        titleTxt.text = pokemonSO.names[0];
        pokemonSprite.sprite = pokemonSO.sprites[0];
    }

    public void SetButton(UnityAction callback)
    {
        pokemonBtn.onClick.AddListener(callback);
    }
}
