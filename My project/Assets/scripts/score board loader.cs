using UnityEngine;
using TMPro;

public class scoreboardloader : MonoBehaviour
{
    public TextMeshProUGUI scoreboardText;
    private int highscore = 0;
    private int secondscore = 0;
    private int thirdscore = 0;
    private int fourthscore = 0;
    private int fifthscore = 0;
    // loading the scoreboard text file
    private void Awake()
    {
        // player prefs
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        secondscore = PlayerPrefs.GetInt("SecondScore", 0);
        thirdscore = PlayerPrefs.GetInt("ThirdScore", 0);
        fourthscore = PlayerPrefs.GetInt("FourthScore", 0);
        fifthscore = PlayerPrefs.GetInt("FifthScore", 0);

        scoreboardText.text = "Highscore: " + highscore.ToString() + "\n" +
            "Second Score: " + secondscore.ToString() + "\n" +
            "Third Score: " + thirdscore.ToString() + "\n" +
            "Fourth Score: " + fourthscore.ToString() + "\n" +
            "Fifth Score: " + fifthscore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
