using UnityEngine.UI;
using UnityEngine;


public class LivesUI : MonoBehaviour
{
    public Text livesText;


    public void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
       
    }
}
