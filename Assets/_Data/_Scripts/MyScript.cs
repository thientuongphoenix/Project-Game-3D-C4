using UnityEngine;

public class MyScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        this.TestClass();
    }

    void TestClass()
    {
        Enemy zombie = new Enemy();
        Enemy wolf = new Enemy();
        Enemy eagle = new Enemy();
        Enemy ghost = new Enemy();

        zombie.Moving();
        wolf.Moving();
        eagle.Moving();
        ghost.Moving();
    }
}
