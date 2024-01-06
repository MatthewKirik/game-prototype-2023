using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;

namespace Assets.Character
{
    public record BulletShotOptions
    {
        public float Accuracy { get; set; } = 1f;
    }

    public class GunController : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public Transform bulletDirector;
        public float bulletSpeed = 10f;

        private BulletShotOptions nextShotOptions = null;
        private float timeToFire = 0;
        private float fireTime = 0.3f;

        public void Fire(BulletShotOptions options)
        {
            if (Time.time >= timeToFire)
            {
                nextShotOptions = options;
            }
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            if (nextShotOptions != null)
            {
                ShootBullet(nextShotOptions);
                timeToFire = Time.time + fireTime;
                nextShotOptions = null;
            }
        }

        private void ShootBullet(BulletShotOptions options)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            var direction = bulletSpawn.position - bulletDirector.position;

            float inaccuracyModifier = (1f - options.Accuracy) * 90;
            float deviationAngle = UnityEngine.Random.Range(-inaccuracyModifier, inaccuracyModifier);
            direction = Quaternion.Euler(0, 0, deviationAngle) * direction;

            bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        }
    }
}
