using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Pokemon", order = 0)]
public class PokemonSO : ScriptableObject
{
    public string pokemon_name;
    public Sprite sprite;
    public GameObject model;
}
