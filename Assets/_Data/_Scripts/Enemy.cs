using UnityEngine;

public class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 2.5f;
    string enemyName = "Enemy";
    bool isDead = true;
    bool isBoss = true;

    EnemyHead head1 = new EnemyHead();
    EnemyHead head2 = new EnemyHead();
    //head1, head2 là đối tượng và EnemyHead là kiểu dữ liệu của đối tượng.
    //Vì head1, head2 được tạo ra bởi class nên được xem là đối tượng (Object)
    EnemyHeart heart = new EnemyHeart();

    string GetName()
    {
        return this.enemyName;
    }

    int GetCurrentHp()
    {
        return this.currentHp;
    }

    float GetWeight()
    {
        return this.weight;
    }

    bool GetIsDead()
    {
        return this.isDead;
    }

    bool IsBoss()
    {
        return this.isBoss;
    }

    public void Moving()
    {
        //Write move logic here
        string logMessage = this.enemyName + " Moving";
        Debug.Log(logMessage);
    }    
}
