using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeMenuScript : MonoBehaviour {

    private GameObject currentGameObject;
    public Image image;
	
	void Start () {
      
	}
	
    public void OnUpgrade()
    {
        Debug.Log("OnUpgrade ");
       currentGameObject.SendMessage("OnUpgrade");
    }
    public void OnCancel()
    {
        Debug.Log("OnCancel ");
       currentGameObject.SendMessage("OnCancel");
    }
    public void setData(GameObject value)
    {
        currentGameObject = value;
        redrawMenu();
    }
    private void redrawMenu()
    {
        LevelUpgrade levelUpgradeData = currentGameObject.GetComponent<LevelUpgrade>();

        Sprite sprite = Resources.Load<Sprite>("Sprites/" + levelUpgradeData.iconPath);
        image.sprite = sprite;
    }
}
