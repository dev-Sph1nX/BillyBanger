using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (GameController._instance == null)
                GameController._instance = FindObjectOfType<GameController>();

            return GameController._instance;
        }
    }
}
