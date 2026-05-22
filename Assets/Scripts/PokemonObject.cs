using UnityEngine;

public class PokemonObject : MonoBehaviour
{
    private GameObject _pokemonObject;

    public void SetObject(GameObject newObject)
    {
        Destroy(_pokemonObject);
        _pokemonObject = Instantiate(newObject, this.transform);
        _pokemonObject.transform.localPosition = Vector3.zero;
        _pokemonObject.transform.localRotation = Quaternion.identity;
        _pokemonObject.transform.localScale = Vector3.one;
    }
}
