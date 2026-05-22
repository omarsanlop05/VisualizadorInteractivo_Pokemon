using TMPro;
using UnityEngine;

public class AppController : MonoBehaviour
{

    [Header("Pokemon")]
    public int StarIndex = 0;
    public PokemonObject pokemonObject;

    [Header("UI")]
    public TextMeshProUGUI titleTxt;
    public Pokemon pokemonPrefab;
    public Transform pokemonContainer;
    public Transform EvolutionContainer;
    public EvolutionButton evolutionButtonPrefab;

    [Header("Data")]
    public PokemonSO[] data;

    private Pokemon _pokemon;
    private PokemonSO currentPokemon;
    private int currentStage;

    private void Start()
    {
        CreatePrefabs();
        //ChangeFurniture(data[StarIndex]);
    }

    private void CreatePrefabs()
    {
        for (int i = 0; i < data.Length; i++)
        {

            _pokemon = Instantiate(pokemonPrefab, pokemonContainer);
            _pokemon.Init(data[i]);

            int index = i;

            _pokemon.SetButton(() => PutPokemon(data[index]));
        }
    }

    void ClearEvolutionButtons()
    {
        foreach (Transform child in EvolutionContainer)
        {
            Destroy(child.gameObject);
        }
    }

    void SelectStage(int stage)
    {
        currentStage = stage;

        titleTxt.text = currentPokemon.names[stage];
        pokemonObject.SetObject(currentPokemon.stages[stage]);
    }

    void CreateEvolutionButtons()
    {
        ClearEvolutionButtons();

        for (int i = 0; i < currentPokemon.names.Length; i++)
        {
            int stageIndex = i;

            EvolutionButton btn = Instantiate(evolutionButtonPrefab, EvolutionContainer);

            btn.Init(
                currentPokemon.names[stageIndex],
                currentPokemon.sprites[stageIndex],
                () => SelectStage(stageIndex)
            );

            btn.SetInteractable(true);
        }
    }

    private void PutPokemon(PokemonSO pokemonSO)
    {
        currentPokemon = pokemonSO;
        currentStage = 0;

        titleTxt.text = pokemonSO.names[currentStage];
        pokemonObject.SetObject(pokemonSO.stages[currentStage]);

        CreateEvolutionButtons();
    }

    /*

    private void PutPokemon(PokemonSO pokemonSO)
    {
        Debug.Log("CLICK en: " + pokemonSO.names[0]);
        titleTxt.text = pokemonSO.names[0];
        pokemonObject.SetObject(pokemonSO.stages[0]);

        currentPokemon = pokemonSO;
        currentStage = 0;

        titleTxt.text = pokemonSO.names[currentStage];
        pokemonObject.SetObject(pokemonSO.stages[currentStage]);
        CreateEvolutionButtons();
    }*/
}