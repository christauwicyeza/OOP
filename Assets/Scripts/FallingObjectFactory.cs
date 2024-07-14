using UnityEngine;

public static class FallingObjectFactory
{
    public static GameObject CreateFallingObject(GameObject prefab, Vector3 position)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity);
    }
}
