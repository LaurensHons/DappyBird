using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleItem : MonoBehaviour, IPointerClickHandler
{
    public Image Image;
    public BirdItem BirdItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BirdItem.Enabled = !BirdItem.Enabled;
    }
}
