- [Test 1: What is best 3D Collider (Fastest & the best in performance)](Testcase1.cs)
  
- Testcase 1: Assign `Collider` to gameObjet and move the gameObject (no interaction). This is the average time after try 10 times.
  - 🏆 BoxCollider: 231.4ms
  - 🔹 SphereCollider: 240.2ms
  - 🔹 CapsuleCollider: 246.1ms
  - 🔹 MeshCollider: 335.7ms
    
- Testcase 2: Assign `Collider` to gameObject and check the collision with a sub gameObject (have BoxCollider). This is the average time after try 10 times.
  - 🔹 BoxCollider: 1265.8ms
  - 🔹 SphereCollider: 1438.4ms
  - 🔹 CapsuleCollider: 1545.6ms
  - 🏆 MeshCollider: 1212.6ms
- 🔥 generally the fastest and should be used when possible =>  `BoxCollider`
  
- [Test 2: Collision collider vs calculator logic (without collider)]()
  
  - Testcase: Spawn 1000 entities and move to random point, check if two entities have interaction
  - Solution 1: Use collider, every entity have a collider and use OnTriggerEnter to check collisitions.
  - Solution 2: Use logic to check collisition between entities.
