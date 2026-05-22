using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Pokemon", order = 0)]
public class PokemonSO : ScriptableObject
{
    public string[] names;
    public Sprite[] sprites;
    public GameObject[] stages;
}
