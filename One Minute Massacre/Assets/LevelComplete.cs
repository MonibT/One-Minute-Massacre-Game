using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public Text TpointsText;


    private void Update()
    {
        //TpointsText.text = "TOTAL POINTS: " + GameManager.instance.totalPoints.ToString();
    }
    public void upgrade()
    {
        SceneManager.LoadScene(3);
    }
    public void nextlevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
