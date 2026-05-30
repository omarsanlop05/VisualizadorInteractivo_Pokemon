using UnityEngine;

public class PokemonObject : MonoBehaviour
{
    [Header("Referencia Inicial")]
    public GameObject pokebolaObject;


    private GameObject _pokemonObject;

    private void Start()
    {
        // ¡La magia de tu idea! Al iniciar, le decimos al script 
        // que el "objeto actual" es la Pokébola física.
        _pokemonObject = pokebolaObject;
    }

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