using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject aboutUs;
    // Use this for initialization
    void Start () {
        menuPanel.SetActive(true)
    ;
        aboutUs.SetActive(false)
  ;
    }
	
	// Update is called once per frame
	
    public void StartGameClicked()
    {
        Application.LoadLevel(0);
    }

    public void aboutClicked()
    {
        aboutUs.SetActive(true);
        menuPanel.SetActive(false);
    }
    public void QuitGameClick()
    {
        Application.Quit();
    }
    public void BacktGameClick()
    {
        menuPanel.SetActive(true)
  ;
        aboutUs.SetActive(false)
  ;
    }


}
