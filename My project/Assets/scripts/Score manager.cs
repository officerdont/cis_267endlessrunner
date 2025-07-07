using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoremanager : MonoBehaviour

{
    public static Scoremanager instance;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI boots;
    public TextMeshProUGUI hammer;
    public TextMeshProUGUI shield;

    private int score = 0;
    private int highscore = 0;
    private int secondscore = 0;
    private int thirdscore = 0;
    private int fourthscore = 0;
    private int fifthscore = 0;

    private int bootsCount = 0;
    private int hammerCount = 0;
    private int shieldCount = 0;

    void Awake()
    {
       instance = this;
        // Load highscore from PlayerPrefs
        // test 
        
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        secondscore = PlayerPrefs.GetInt("SecondScore", 0);
        thirdscore = PlayerPrefs.GetInt("ThirdScore", 0);
        fourthscore = PlayerPrefs.GetInt("FourthScore", 0);
        fifthscore = PlayerPrefs.GetInt("FifthScore", 0);

        highscoreText.text = "Highscore: " + highscore.ToString();
    }


    void Start()
    {
       
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
        boots.text = "Boots: " + bootsCount.ToString();
        hammer.text = "Hammer: " + hammerCount.ToString();
        shield.text = "Shield: " + shieldCount.ToString();


    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        if (score > highscore)
        {
            
            highscoreText.text = "Highscore: " + score.ToString();
        }


        

       
    }
    public void AddBoots(int count)
    {
        bootsCount += count;
        boots.text = "Boots: " + bootsCount.ToString();
    }
    public void AddHammer(int count)
    {
        hammerCount += count;
        hammer.text = "Hammer: " + hammerCount.ToString();
    }
    public void AddShield(int count)
    {
        shieldCount += count;
        shield.text = "Shield: " + shieldCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // add points every second
        if (Time.timeSinceLevelLoad % 1 < 0.1f) // every second
        {
            AddScore(1);
        }
    }

    // Save the highscore and other scores to PlayerPrefs when the game ends
    public void changescores()
            {
        if (score > highscore)
        {
            fifthscore = fourthscore;
            fourthscore = thirdscore;
            thirdscore = secondscore;
            secondscore = highscore;
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.SetInt("SecondScore", secondscore);
            PlayerPrefs.SetInt("ThirdScore", thirdscore);
            PlayerPrefs.SetInt("FourthScore", fourthscore);
            PlayerPrefs.SetInt("FifthScore", fifthscore);
        }
        else if (score > secondscore)
        {
            fifthscore = fourthscore;
            fourthscore = thirdscore;
            thirdscore = secondscore;
            secondscore = score;
            PlayerPrefs.SetInt("SecondScore", secondscore);
            PlayerPrefs.SetInt("ThirdScore", thirdscore);
            PlayerPrefs.SetInt("FourthScore", fourthscore);
            PlayerPrefs.SetInt("FifthScore", fifthscore);
        }
        else if (score > thirdscore)
        {
            fifthscore = fourthscore;
            fourthscore = thirdscore;
            thirdscore = score;
            PlayerPrefs.SetInt("ThirdScore", thirdscore);
            PlayerPrefs.SetInt("FourthScore", fourthscore);
            PlayerPrefs.SetInt("FifthScore", fifthscore);
        }
        else if (score > fourthscore)
        {
            fifthscore = fourthscore;
            fourthscore = score;
            PlayerPrefs.SetInt("FourthScore", fourthscore);
            PlayerPrefs.SetInt("FifthScore", fifthscore);
        }
        else if (score > fifthscore)
        {
            fifthscore = score;
            PlayerPrefs.SetInt("FifthScore", fifthscore);
        }
        // Save all scores
        PlayerPrefs.Save();

    }
}
