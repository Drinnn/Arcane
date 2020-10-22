using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour {
    private ResourceTypeListSO _resourceTypeList;
    private Dictionary<ResourceTypeSO, Transform> _resourceTypeTransformDictionary;

    private void Awake() {
        _resourceTypeList = Resources.Load<ResourceTypeListSO>(nameof(ResourceTypeListSO));
        _resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();

        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in _resourceTypeList.list) {
            Transform resourceTemplateClone = Instantiate(resourceTemplate, transform);
            resourceTemplateClone.gameObject.SetActive(true);

            float offsetAmount = -160f;
            resourceTemplateClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            resourceTemplateClone.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            _resourceTypeTransformDictionary[resourceType] = resourceTemplateClone;

            index++;
        }

    }

    private void Start() {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e) {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount() {
        foreach (ResourceTypeSO resourceType in _resourceTypeList.list) {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            Transform resourceTransform = _resourceTypeTransformDictionary[resourceType];

            resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}
