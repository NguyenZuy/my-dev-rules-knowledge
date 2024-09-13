using UnityEngine;
using System.Diagnostics;

public class Testcase1 : MonoBehaviour
{
    public GameObject boxColliderObject;
    public GameObject sphereColliderObject;
    public GameObject capsuleColliderObject;
    public GameObject meshColliderObject;
    public GameObject cubeColliderObject; // The common cube collider for comparison

    public int numTests = 1;

    private void Start()
    {
        TestColliderPerformance(boxColliderObject, "BoxCollider");
        TestColliderPerformance(sphereColliderObject, "SphereCollider");
        TestColliderPerformance(capsuleColliderObject, "CapsuleCollider");
        TestColliderPerformance(meshColliderObject, "MeshCollider");

        TestCollisionPerformance(boxColliderObject, cubeColliderObject, "BoxCollider vs CubeCollider");
        TestCollisionPerformance(sphereColliderObject, cubeColliderObject, "SphereCollider vs CubeCollider");
        TestCollisionPerformance(capsuleColliderObject, cubeColliderObject, "CapsuleCollider vs CubeCollider");
        TestCollisionPerformance(meshColliderObject, cubeColliderObject, "MeshCollider vs CubeCollider");
    }

    private void TestColliderPerformance(GameObject obj, string colliderName)
    {
        long totalMilliseconds = 0;

        for (int test = 0; test < numTests; test++)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Perform some operations with the collider
            for (int i = 0; i < 100000; i++)
            {
                obj.transform.position = new Vector3(i % 10, i % 10, i % 10);
                Physics.SyncTransforms(); // Ensure physics engine updates
            }

            stopwatch.Stop();
            totalMilliseconds += stopwatch.ElapsedMilliseconds;
        }

        float averageMilliseconds = totalMilliseconds / (float)numTests;
        UnityEngine.Debug.Log($"{colliderName} average time over {numTests} tests: {averageMilliseconds} ms");
    }

    private void TestCollisionPerformance(GameObject obj1, GameObject obj2, string testName)
    {
        long totalMilliseconds = 0;

        Vector3 initialPosition1 = obj1.transform.position;
        Vector3 initialPosition2 = obj2.transform.position;

        for (int test = 0; test < numTests; test++)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Perform collision checks
            for (int i = 0; i < 100000; i++)
            {
                obj1.transform.position = new Vector3(i % 10, i % 10, i % 10);
                obj2.transform.position = new Vector3((i + 5) % 10, (i + 5) % 10, (i + 5) % 10);
                Physics.SyncTransforms(); // Ensure physics engine updates

                // Check for collision
                bool isColliding = obj1.transform.GetChild(1).GetComponent<Collider>().bounds.Intersects(obj2.transform.GetChild(1).GetComponent<Collider>().bounds);
            }

            stopwatch.Stop();
            totalMilliseconds += stopwatch.ElapsedMilliseconds;

            // Reset positions
            obj1.transform.position = initialPosition1;
            obj2.transform.position = initialPosition2;
        }

        float averageMilliseconds = totalMilliseconds / (float)numTests;
        UnityEngine.Debug.Log($"{testName} average time over {numTests} tests: {averageMilliseconds} ms");
    }
}
