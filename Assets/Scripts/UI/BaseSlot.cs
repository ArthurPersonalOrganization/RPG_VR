using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class BaseSlot : MonoBehaviour
    {

        public InventoryItem inventoryItem;
        protected Image image;
        protected Button button;
        protected void Awake()
        {
            Transform icon = transform.Find("Icon");
            image = icon.GetComponent<Image>();
            button = GetComponent<Button>();
        }

        public void Set(InventoryItem inventoryItem)
        {
            this.inventoryItem = inventoryItem;
            image.sprite = inventoryItem.definition.GetStaticProperty("sprite").AsAsset<Sprite>();
            image.enabled = true;
            button.interactable = true;
        }

        public void UnSet()
        {
            inventoryItem = null;
            image.sprite = null;
            image.enabled = false;
            button.interactable = false;
        }

    }


}

