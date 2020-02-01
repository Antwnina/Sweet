using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelController : MonoBehaviour {

	public GameObject winPanel;
	public GameObject losePanel;
    	
	// Update is called once per frame
	void Update () {
        
        if (!GameHandler.HasBearLifes() && winPanel != null) //win
        {            
            winPanel.gameObject.SetActive (true);
        }
        else if (!GameHandler.HasLifes() && losePanel != null) //lose
        {            
            losePanel.gameObject.SetActive (true);
		}
    }

    public void RestartLevel()
    {
        GameHandler.AddLife();
        GameHandler.AddLife();
        GameHandler.AddLife();
        GameHandler.ClearScore();
        GameHandler.ResetLatestCheckpointPosition();
        GameHandler.AddBearLifes(20);
        SceneManager.LoadScene(1);
    }
    
   


}
