using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPool<T> where T : MonoBehaviour
{
    GameObject prefab;
    Transform parent;

    List<GameObject> miniPools = new List<GameObject>();
    public Dictionary<GameObject, T> dict = new Dictionary<GameObject, T>();

    public MiniPool(GameObject prefab, int amount, Transform parent)// chinh la preload luon
    {
        this.prefab = prefab;
        this.parent = parent;

        for (int i = 0; i < amount; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            miniPools.Add(obj);
            obj.SetActive(false);

        }
    }

    public T Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject obj = null;

        for (int i = 0; i < miniPools.Count; i++)
        {
            if (!miniPools[i].activeInHierarchy)
            {
                obj = miniPools[i];
            }
        }

        if (obj == null)
        {
            obj = GameObject.Instantiate(prefab, parent);
        }

        obj.transform.SetPositionAndRotation(position, rotation);
        obj.SetActive(true);

        if (!dict.ContainsKey(obj))
        {
            dict.Add(obj, obj.GetComponent<T>());
            miniPools.Add(obj);
        }

        return dict[obj];
    }

    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void Collect()
    {
        for (int i = 0; i < miniPools.Count; i++)
        {
            miniPools[i].SetActive(false);
        }
    }
}
