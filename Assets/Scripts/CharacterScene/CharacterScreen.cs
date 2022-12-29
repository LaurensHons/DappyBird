using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScreen : MonoBehaviour
{
    public GameObject BirdPrefab;
    public GameObject BirdPlaceHolder;

    public GameObject CharacterItemPrefab;
    public GameObject CharacterItemList;
    
    public BirdItem[] BirdItems;

    private GameData localSave;
    
    void Start()
    {
        localSave = SaveInterface.LoadFile();
        
        foreach (var birdItem in BirdItems)
        {
            BirdItemData savedItem = null;
            if (localSave.BirdItems != null)
            {
                foreach (var localsave in localSave.BirdItems)
                {
                    if (localsave.Name == birdItem.gameObject.name) savedItem = localsave;
                }
                if (savedItem != null)
                {
                    Debug.Log("found saved item: " + savedItem.Name);
                    birdItem.setData(savedItem);
                }
            }
            
            var characterItem = Instantiate(CharacterItemPrefab, CharacterItemList.transform);
            var toggleItem = characterItem.GetComponent<ToggleItem>();
            toggleItem.Image.sprite = birdItem.Image.sprite;
            toggleItem.BirdItem = birdItem;
        }
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GoToMainScene()
    {
        saveItems();
        SceneManager.LoadScene(1);
    }

    private void saveItems()
    {
        var birdItemData = new List<BirdItemData>() { };
        foreach (var birdItem in BirdItems)
        {
            birdItemData.Add(birdItem.BirdItemData);
        }
        Debug.Log(birdItemData);
        localSave.BirdItems = birdItemData.ToArray();
        SaveInterface.SaveFile(localSave);
    }
}
