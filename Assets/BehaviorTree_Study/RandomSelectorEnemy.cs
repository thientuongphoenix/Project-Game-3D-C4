using System.Collections.Generic;
using UnityEngine;

//Random Selector
public class RandomSelectorEnemy : Node
{
    private List<Node> childrenEnemy;
    private List<float> weightsEnemy;
    private System.Random random = new System.Random();

    public RandomSelectorEnemy(List<Node> childrenEnemy, List<float> weightsEnemy)
    {
        this.childrenEnemy = childrenEnemy;
        this.weightsEnemy = weightsEnemy;
    }

    public override Status Process()
    {
        // Tính tổng trọng số
        float total = 0;
        foreach (var w in weightsEnemy) total += w;
        float r = (float)(random.NextDouble() * total);
        float sum = 0;
        for (int i = 0; i < childrenEnemy.Count; i++)
        {
            sum += weightsEnemy[i];
            if (r <= sum)
            {
                var status = childrenEnemy[i].Process();
                if (status == Status.FAILURE)
                {
                    // Nếu node này không khả dụng, thử random lại
                    float newR = (float)(random.NextDouble() * total);
                    sum = 0;
                    for (int j = 0; j < childrenEnemy.Count; j++)
                    {
                        if (j == i) continue; // Bỏ qua node đã thất bại
                        sum += weightsEnemy[j];
                        if (newR <= sum)
                        {
                            return childrenEnemy[j].Process();
                        }
                    }
                }
                return status;
            }
        }
        return Status.FAILURE;
    }
}
