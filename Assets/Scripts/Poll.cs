using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Poll<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab { get; }
    public bool _autoExpand { get; set; }
    [SerializeField] private Transform _container { get; }

    private List<T> _pool;

    public Poll(T prefab, int count)
    {
        _prefab = prefab;
        _container = null;

        CreatePool(count);
    }

    public Poll(T prefab, int count, Transform container)
    {
        this._prefab = prefab;
        _container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var cube in _pool)
        {
            if (!cube.gameObject.activeInHierarchy)
            {
                element = cube;
                cube.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }

        if (_autoExpand)
        {
            return CreateObject(true);
        }

        throw new Exception($"� ���� ��� ��������� ��������� ���� {typeof(T)}");
    }
}
