using UnityEngine;

public class GameControllerLogic : MonoBehaviour
{
    public int gameSpeed = 1;
    private float gameTime = 0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        gameTime += Time.deltaTime;
        if(Mathf.RoundToInt(gameTime) > 10)
            gameSpeed = Mathf.RoundToInt(gameTime) / 10;
    }
}
