using UnityEngine;
using System.Collections;

public class LevelData :MonoBehaviour{

    private int _level;
    public int level 
    {
        get { return _level; }
        set { _level = value; }
    }

    private string _name;
    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _iconPath;
    public string iconPath
    {
        get { return _iconPath; }
        set { _iconPath = value; }
    }

}
