using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BirdItem : MonoBehaviour
{
    public BirdItemData BirdItemData { private set; get; }

    public void setData(BirdItemData birdItemData)
    {
        this.BirdItemData = birdItemData;
        Image.enabled = BirdItemData.Enabled;
    }
    public string Name
    {
        get { return BirdItemData.Name; }
        set
        {
            if (BirdItemData == null) BirdItemData = new BirdItemData();
            BirdItemData.Name = value;
        }
    }
    public bool Enabled
    {
        get { return BirdItemData.Enabled; }
        set
        {
            Image.enabled = value;
            BirdItemData.Enabled = value;
        }
        
    }

    public Image Image;
    
    void Start()
    {
        Name = this.gameObject.name;
        Image = this.GetComponent<Image>();
    }
}
