using System.Collections.Generic;
using UnityEngine;

namespace StrategyPatternExample
{
    public interface IShootingStrategy
    {
        List<ProjectileData> GetProjectileDatas(int amount, Vector3 centerPoint, float minDistance = 1, float totalTime = 0);
    }

    public class ProjectileData
    {
        public Vector2 position;
        public Quaternion rotation;
        public float delay;
    }
}