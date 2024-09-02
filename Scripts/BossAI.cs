using UnityEngine;

namespace StrategyPatternExample
{
    public class BossAI : MonoBehaviour
    {
        [SerializeField] private ShootingAbility shootingAbility;
        [SerializeField] private ShootingStrategy shootingStrategy;
        private ShootingStrategy lastShootingStrategy;

        private void Start()
        {
            UpdateShootingStrategy();
        }

        private void Update()
        {
            if (shootingStrategy != lastShootingStrategy)
            {
                lastShootingStrategy = shootingStrategy;
                UpdateShootingStrategy();
            }
        }

        private void UpdateShootingStrategy()
        {
            IShootingStrategy strategy = null;

            switch (shootingStrategy)
            {
                case ShootingStrategy.Circle:
                    strategy = new CircleShootingStrategy();
                    break;
                case ShootingStrategy.Random:
                    strategy = new RandomShootingStrategy();
                    break;
                case ShootingStrategy.Square:
                    strategy = new SquareShootingStrategy();
                    break;
                default:
                    Debug.Log("Shooting strategy couldn't be created!");
                    break;
            }

            shootingAbility.shootingStrategy = strategy;
        }

        private enum ShootingStrategy { Circle, Random, Square };
    }
}