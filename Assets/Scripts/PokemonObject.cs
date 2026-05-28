using UnityEngine;

public class PokemonObject : MonoBehaviour
{
    private GameObject _pokemonObject;

    // Cambiamos void por GameObject para retornar el objeto creado
    public GameObject SetObject(GameObject newObject)
    {
        if (_pokemonObject != null)
        {
            Destroy(_pokemonObject);
        }

        _pokemonObject = Instantiate(newObject, this.transform);
        _pokemonObject.transform.localPosition = Vector3.zero;
        _pokemonObject.transform.localRotation = Quaternion.identity;
        // Ajusta el scale aquí si tus modelos 3D son muy grandes o pequeños
        _pokemonObject.transform.localScale = Vector3.one;

        return _pokemonObject;
    }
}