using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{
    [Header("UI - Menú Batalla (Arriba)")]
    public Button btnIdle;
    public Button btnRun;
    public Button btnFightIdle;
    public Button btnFireball;
    public Button btnFlipKick;

    [Header("UI - Selector (Abajo)")]
    public TextMeshProUGUI titleTxt;
    public Pokemon pokemonPrefab;
    public Transform pokemonContainer;

    [Header("AR y Datos")]
    public PokemonObject pokemonObject;
    public PokemonSO[] data;

    private Animator _currentAnimator;

    private void Start()
    {
        CreatePokemonSelector();
        SetupAnimationButtons();
    }

    private void CreatePokemonSelector()
    {
        for (int i = 0; i < data.Length; i++)
        {
            Pokemon _pokemon = Instantiate(pokemonPrefab, pokemonContainer);
            _pokemon.Init(data[i]);

            int index = i;
            _pokemon.SetButton(() => PutPokemon(data[index]));
        }
    }

    private void SetupAnimationButtons()
    {
        // Asignamos los triggers del Animator a cada botón
        btnIdle.onClick.AddListener(() => PlayAnim("Idle"));
        btnRun.onClick.AddListener(() => PlayAnim("Run"));
        btnFightIdle.onClick.AddListener(() => PlayAnim("Fight"));
        btnFireball.onClick.AddListener(() => PlayAnim("Fireball"));
        btnFlipKick.onClick.AddListener(() => PlayAnim("Kick"));
    }

    private void PutPokemon(PokemonSO pokemonSO)
    {
        // Actualizamos el nombre en la UI
        titleTxt.text = pokemonSO.pokemon_name;

        // Instanciamos el modelo 3D (usamos stage[0] porque ya no hay evoluciones)
        GameObject spawnedModel = pokemonObject.SetObject(pokemonSO.model);

        // Obtenemos el Animator del nuevo Pokémon para poder animarlo
        if (spawnedModel != null)
        {
            _currentAnimator = spawnedModel.GetComponent<Animator>();
        }
    }

    private void PlayAnim(string triggerName)
    {
        if (_currentAnimator != null)
        {
            _currentAnimator.SetTrigger(triggerName);
        }
        else
        {
            Debug.LogWarning("¡Selecciona un Pokémon primero!");
        }
    }
}