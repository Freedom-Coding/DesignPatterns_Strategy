using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternExample
{
    public class SquareShootingStrategy : IShootingStrategy
    {
        const int SIDES = 4;

        public List<ProjectileData> GetProjectileDatas(int amount, Vector3 centerPoint, float minDistance = 1, float totalTime = 0)
        {
            if (amount <= 0) return null;

            List<ProjectileData> projectileDatas = new();

            int projectilesPerSide = Mathf.CeilToInt((float)amount / SIDES);
            float halfSide = (projectilesPerSide - 1) * minDistance / 2;
            int totalAmount = 0;

            for (int side = 0; side < SIDES; side++)
            {
                for (int i = 0; i < projectilesPerSide && totalAmount < amount; i++)
                {
                    float x = 0, y = 0;

                    switch (side)
                    {
                        case 0: // Top side
                            x = centerPoint.x - halfSide + i * minDistance;
                            y = centerPoint.y + halfSide;
                            break;
                        case 1: // Right side
                            x = centerPoint.x + halfSide;
                            y = centerPoint.y + halfSide - i * minDistance;
                            break;
                        case 2: // Bottom side
                            x = centerPoint.x + halfSide - i * minDistance;
                            y = centerPoint.y - halfSide;
                            break;
                        case 3: // Left side
                            x = centerPoint.x - halfSide;
                            y = centerPoint.y - halfSide + i * minDistance;
                            break;
                    }

                    ProjectileData projectileData = new();
                    projectileData.position = new Vector2(x, y);
                    Vector2 direction = (projectileData.position - (Vector2)centerPoint).normalized;

                    float angleDirection = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    projectileData.rotation = Quaternion.Euler(new Vector3(0, 0, angleDirection - 90f));

                    totalAmount++;
                    projectileDatas.Add(projectileData);
                }
            }

            return projectileDatas;
        }
    }
}
