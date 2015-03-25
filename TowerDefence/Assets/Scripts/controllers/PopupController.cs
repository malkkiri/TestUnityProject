using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupController : MonoBehaviour {

    public enum WindowsTypes{UPGRADE_MENU,EMPTY};

    public GameObject upgradeMenu;
    public Canvas canvas;
  //  public Camera secondCamera;

    private Dictionary<WindowsTypes, GameObject> windowsDict = new Dictionary<WindowsTypes, GameObject>();

    private WindowsTypes currentWindowType;

	void Start () {
        setDict();
        currentWindowType = WindowsTypes.EMPTY;
        upgradeMenu.SetActive(false);
	}
    private void setDict()
    {
        windowsDict.Add(WindowsTypes.UPGRADE_MENU, upgradeMenu);
    }
    
    public void showWindow(WindowsTypes valueType, GameObject value)
    {
        if (currentWindowType==valueType) return;
        
        GameObject currentWindow=null;
        windowsDict.TryGetValue(valueType, out currentWindow);
        if (currentWindow == null) return;

        currentWindowType = valueType;
        GameObject currentGameObject = value;
        currentWindow.SetActive(true);
        
        Vector3 itemPosition = value.transform.position;
        Vector2 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, itemPosition);
        screenPosition.y += 150;
        currentWindow.transform.position = screenPosition;
        
        //switch for current Script
        UpgradeMenuScript upgradeMenuScript = currentWindow.GetComponent<UpgradeMenuScript>();
        upgradeMenuScript.setData(currentGameObject);
    }
    
    public void hideWindow(WindowsTypes valueType)
    {
        GameObject currentWindow = null;
        windowsDict.TryGetValue(valueType, out currentWindow);
        if (currentWindow == null) return;

        currentWindow.SetActive(false);
        if (currentWindowType == valueType)
        {
            currentWindowType = WindowsTypes.EMPTY;
        }
    }

}
