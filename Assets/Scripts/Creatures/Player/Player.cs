using UnityEngine.SceneManagement;

public class Player : Creature
{
    public override void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
