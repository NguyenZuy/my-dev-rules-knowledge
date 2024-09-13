## Test 1: What is best Collider (Fastest & the best in performance)
- Testcase 1: Assign `Collider` to gameObjet and move the gameObject (no interaction). This is the average time after try 10 times.
  🏆 BoxCollider: 231.4ms
  🔹 SphereCollider: 240.2ms
  🔹 CapsuleCollider: 246.1ms
  🔹 MeshCollider: 335.7ms
- Testcase 2: Assign `Collider` to gameObject and check the collision with a sub gameObject (have BoxCollider). This is the average time after try 10 times.
  🔹 BoxCollider: 1265.8ms
  🔹 SphereCollider: 1438.4ms
  🔹 CapsuleCollider: 1545.6ms
  🏆 MeshCollider: 1212.6ms
🔥 `BoxCollider` generally the fastest and should be used when possible.
