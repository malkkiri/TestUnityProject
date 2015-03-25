using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

   static GameController mInstance;
   public PopupController popupController;

    public static GameController Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject go = new GameObject();
                mInstance = go.AddComponent<GameController>();
            }
            return mInstance;
        }
    }

	void Start () {
        Debug.Log(" START GAME CONTROLLER");
        mInstance = this;
	}
    
}
