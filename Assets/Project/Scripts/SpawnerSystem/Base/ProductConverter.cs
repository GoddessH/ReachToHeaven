using TMPro;
using UnityEngine;

public static class ProductConverter
{
    //
    public static IProduct MonoToIProduct(MonoBehaviour monoBehaviour)
    {
        if (monoBehaviour is IProduct product) return product;

        Debug.LogWarning($"{monoBehaviour}: MonoBehaviour doesn't implement IProduct");
        return null;
    }

    public static MonoBehaviour IProductToMono(IProduct product)
    {
        return product as MonoBehaviour;
    }

    public static T IProductToAnyType<T>(IProduct product) where T : class
    {
        return product as T;
    }
}
