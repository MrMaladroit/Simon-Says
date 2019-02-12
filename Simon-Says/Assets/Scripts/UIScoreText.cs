using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : MonoBehaviour
{
    [SerializeField] Text _currentStreakText;
    [SerializeField] Text _highscoreText;

    public void SetCurrentStreakText(int streak)
    {
        _currentStreakText.text = "Current Streak: " + streak.ToString();
    }

    public void SetHighscoreText(int streak)
    {
        _highscoreText.text = "High Score: " +  streak.ToString();
        if (streak > PlayerPrefs.GetInt("High Score"))
        {
            PlayerPrefs.SetInt("High score", streak);
        }
    }
}