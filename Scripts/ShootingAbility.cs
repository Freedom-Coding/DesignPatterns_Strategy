using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace StrategyPatternExample
{
    public class ShootingAbility : MonoBehaviour
    {
        public IShootingStrategy shootingStrategy;

        [SerializeField] private float projectileSpeed = 5;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int projectileAmount = 10;
        [SerializeField] private float shootTime = 0;
        [SerializeField] private float startDistance = 1;
        [SerializeField] private Transform startPoint;

        private async void Start()
        {
            while (true)
            {
                await Task.Delay(1000);

                if (!Application.isPlaying) return;

                Shoot();
            }
        }

        private async void Shoot()
        {
            List<ProjectileData> projectileDatas = shootingStrategy.GetProjectileDatas(projectileAmount, startPoint.position, startDistance, shootTime);

            foreach (ProjectileData data in projectileDatas)
            {
                GameObject projectile = Instantiate(projectilePrefab, data.position, data.rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * projectileSpeed;
                Destroy(projectile, 5);
                await Task.Delay((int)(data.delay * 1000));
                if (!Application.isPlaying) return;
            }
        }
    }
}