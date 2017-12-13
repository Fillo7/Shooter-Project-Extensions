using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.

    private Text text;              // Reference to the Text component.

    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        text.text = "Score: " + score;
    }
}
