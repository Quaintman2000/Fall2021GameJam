using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HighScoreManager : MonoBehaviour
{
    public List<int> highScores = new List<int>();
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        // Grab the score from the game manager and store it in the list.
        // If there's more than 5 in the list, remove the lowest score.
        if(highScores.Count == 5)
        {
            highScores.RemoveAt(4);
        }

        highScores.Add(GameManager.instance.points);
        // Sort the scores in ascending order.
        highScores.Sort();
        // Reverse the order to decending.
        highScores.Reverse();

        for (int row = 0; row <highScores.Count; row++)
        {
            string newLine = string.Format("{0}. {1} points!\n", (row + 1), highScores[row]);
            highScoreText.text += newLine;
        }
    }

   public void ReturnClicked()
    {
        GameManager.instance.ResetData();
        SceneManager.LoadScene(0);
    }
}

