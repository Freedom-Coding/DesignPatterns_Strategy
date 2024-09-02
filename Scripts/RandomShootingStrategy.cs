using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternExample
{
    public class RandomShootingStrategy : IShootingStrategy
    {
        public List<ProjectileData> GetProjectileDatas(int amount, Vector3 centerPoint, float minDistance = 1, float totalTime = 0)
        {
            if (amount <= 0) return null;

            List<ProjectileData> projectileDatas = new();

            for (int i = 0; i < amount; i++)
            {
                float angle = Random.Range(0, 360);
                float x = centerPoint.x + (Mathf.Cos(angle * i) * minDistance);
                float y = centerPoint.y + (Mathf.Sin(angle * i) * minDistance);

                ProjectileData projectileData = new();
                projectileData.position = new Vector2(x, y);
                Vector2 direction = (projectileData.position - (Vector2)centerPoint).normalized;

                float angleDirection = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + Random.Range(-45, 45);
                projectileData.rotation = Quaternion.Euler(new Vector3(0, 0, angleDirection - 90f));

                projectileData.delay = totalTime / amount;
                projectileDatas.Add(projectileData);
            }

            return projectileDatas;
        }
    }
}
