﻿using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    private Dictionary<ResourceTypeSO, int> _resourceAmountDictionary;

    private void Awake() {
        _resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));

        foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
            _resourceAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void TestLogResourceAmountDictionary() {
        foreach (ResourceTypeSO resourceType in _resourceAmountDictionary.Keys) {
            Debug.Log($"{resourceType.name}: {_resourceAmountDictionary[resourceType]}");
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount) {
        _resourceAmountDictionary[resourceType] += amount;
    }
}