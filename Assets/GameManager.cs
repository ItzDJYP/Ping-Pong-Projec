using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public static int CPUScore = 0;
    public GUISkin layout;
    GameObject theBall;

    public enum GameMode{
        PlayerVsCPU,
        PlayerVsPlayer
    }
    public static GameMode gameMode = GameMode.PlayerVsPlayer;

    public static GameMode DetermineGameMode()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.Equals("vsPlayer"))
        {
            return GameMode.PlayerVsPlayer;
        }
        else if (currentSceneName.Equals("vsCPU"))
        {
            return GameMode.PlayerVsCPU;
        }

        // Default to PlayerVsPlayer if the scene name doesn't match either
        return GameMode.PlayerVsPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameMode = DetermineGameMode();
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Scoring System
    public static void Score(string wallId){
        if(wallId.Equals("rightwall")){
            PlayerScore1++;
        }
        else{
            PlayerScore2++;
            CPUScore++;
        }
    }

    // GUI 
    void OnGUI() {
        // Creates layout for GUI
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 1000), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 1000), "" + PlayerScore2);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 1000), "" + CPUScore);
        // Creates Restart Button
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")){
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            CPUScore = 0;
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        // If Players 1 or 2 or CPU win
        if (PlayerScore1 == 5 || PlayerScore2 == 5 || CPUScore == 5)
        {
            string winnerLabel = "";
            if (gameMode == GameMode.PlayerVsPlayer)
            {
                if (PlayerScore1 == 5)
                    winnerLabel = "Player 1 WINS!";
                else if (PlayerScore2 == 5)
                    winnerLabel = "Player 2 WINS!";
            }
            else if (gameMode == GameMode.PlayerVsCPU)
            {
                if (PlayerScore1 == 5)
                    winnerLabel = "Player 1 WINS!";
                if (CPUScore == 5)
                    winnerLabel = "CPU WINS!";
            }

            GUI.Box(new Rect(Screen.width / 2 - 150, 200, 300, 100), winnerLabel);
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
        }
    }