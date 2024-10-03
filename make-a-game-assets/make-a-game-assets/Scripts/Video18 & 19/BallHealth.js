public class YourScript : MonoBehaviour
{
    public int maxFallDistance = -10;
    public GameMaster gameMaster;

    void Update()
    {
        if (transform.position.y <= maxFallDistance)
        {
            if (!GameMaster.isRestarting)
            {
                gameMaster.RestartLevel();
            }
        }
    }
}