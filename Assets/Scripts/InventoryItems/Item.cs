using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string definitionKey;
    public InventoryItem InventoryItem { get; private set; }

    public void Start()
    {
        InventoryItemDefinition itemDefinition = 
            GameFoundationSdk.catalog.Find<InventoryItemDefinition>(definitionKey);

        InventoryItem = GameFoundationSdk.inventory.CreateItem(itemDefinition);
    }
}
