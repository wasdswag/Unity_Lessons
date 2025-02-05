using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Rigidbody body;

   public void Init(Vector3 direction, float speed)
   {
      body = GetComponent<Rigidbody>();
      body.AddForce(direction * speed, ForceMode.Impulse);
   }
   
   private void OnCollisionEnter(Collision col)
   {
      Collider other = col.collider;
      if (other.TryGetComponent(out Invader invader))
      {
          invader.Kill();
          Destroy(gameObject);
      }
      
      else if(other.TryGetComponent(out Player player))
      {
         player.TakeDamage();
         Destroy(gameObject);
      }
      
      else if (other.TryGetComponent(out ShieldVoxel voxel))
      {
         Destroy(voxel.gameObject);
         Destroy(gameObject);
      }
      
      else
      {
         Destroy(gameObject);
      }
      
      

   }
}
