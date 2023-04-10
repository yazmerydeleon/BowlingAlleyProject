using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartSomething()
    {
        SceneManager.LoadScene("BowlingAlley");
    }

    // Update is called once per frame
    void QuitSomething()
    {
        Application.Quit();
    }

   public void startAltMap()
    {

    }

}
