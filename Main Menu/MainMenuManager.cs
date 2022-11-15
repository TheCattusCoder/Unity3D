using System.Collections;
using System.Collection.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    //This is the method that runs to change the scene.
    //It is public to allow it to be called in the editor and by external scripts.
    public void StartGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    //This is the method that runs to close the game.
    //It is public also to allow it to be called by external scripts or the editor.
    public void ExitGame()
    {
        Application.Quit();
    }
}
