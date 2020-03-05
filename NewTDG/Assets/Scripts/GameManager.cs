using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    private int num= 1;

    private void Update()
    {
        if (gameHasEnded)
        {   
            return;
        }

        if (PlayerStats.Lives <=0)
        {
            gameEnd();
        }
    }

     void gameEnd()
    {
        gameHasEnded = true;
        Debug.Log(" GAME OVER " + num);

    }

}
