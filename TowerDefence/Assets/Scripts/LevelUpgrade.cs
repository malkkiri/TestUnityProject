using UnityEngine;
using System.Collections;

public class LevelUpgrade : MonoBehaviour {

	public GameObject nextLevel;
    public GameObject nguiMenu;
    public Camera secondCamera;
    private GameObject menu;
    private bool isDebug;

    [SerializeField]
    private int _level;
    public int level
    {
        get { return _level; }
        set { _level = value; }
    }

    [SerializeField]
    private string _toweName;
    public string toweName
    {
        get { return _toweName; }
        set { _toweName = value; }
    }
    [SerializeField]
    private string _iconPath;
    public string iconPath
    {
        get { return _iconPath; }
        set { _iconPath = value; }
    }
    
	// Use this for initialization
	void Start () {
        //isDebug = true;
	}
	
	void OnMouseDown(){
        GameController.Instance.popupController.showWindow(PopupController.WindowsTypes.UPGRADE_MENU, this.gameObject);
	}
    public void OnUpgrade()
    {
        Debug.Log("LevelUpgrade OnUpgrade ");
        if(isDebug){
            Instantiate(nextLevel, this.transform.position + new Vector3(1, 1, 1), this.transform.rotation);
        }
        else
        {
            Instantiate(nextLevel, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }   
        removeMenu();
    }
    public void OnCancel()
    {
        Debug.Log("LevelUpgrade OnCancel ");
        removeMenu();
    }
    void removeMenu()
    {
        GameController.Instance.popupController.hideWindow(PopupController.WindowsTypes.UPGRADE_MENU);    
    }
}
