using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void Playgame()
    {
             SceneManager.LoadScene( 1 );
    }

    public void SCOREBOARD()
    {
        SceneManager.LoadScene(2);
    }
    public void Quitgame()
     {
          Debug.Log("Quit");
          Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
