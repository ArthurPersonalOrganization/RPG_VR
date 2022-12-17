using Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;
using UnityEngine.Promise;

public class Inventory : MonoBehaviour
{
    public ItemList Items { get; private set; }

    IEnumerator Start()
    {
        MemoryDataLayer dataLayer = new MemoryDataLayer();
        using (Deferred initialization = GameFoundationSdk.Initialize(dataLayer))
        {
            yield return initialization.Wait();
        }

        // Verify that the manager is initialized.
        if (GameFoundationSdk.inventory != null)
        {
            Debug.Log("Game Foundation is installed and ready!");
        }
        else
        {
            Debug.LogError("Error:  Game Foundation was unable to initialize. Please check online help or docs for more information.");
        }


        if (Items == null)
        {
            Items = GameFoundationSdk.inventory.CreateList();
        }
    }

    private void OnEnable()
    {
        EventManager.Instance.OnEquip += Add;
        EventManager.Instance.OnUnequip += Remove;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnEquip -= Add;
        EventManager.Instance.OnUnequip -= Remove;
    }

    private void Add(InventoryItem item)
    {
        Items.Add(item);
    }

    private void Remove(InventoryItem item)
    {
        Items.Remove(item);
    }

    private void Awake()
    {
        
    }

    public void Add(Item item)
    {
        Items.Add(item.InventoryItem);
        Debug.Log(message:$"Added {item.InventoryItem.definition.displayName} to invenory") ;
        Destroy(item.gameObject);
    }
 
}
