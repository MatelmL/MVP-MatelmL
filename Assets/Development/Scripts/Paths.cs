using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    [SerializeField] List<List<Transform>> paths;
    public Transform DoorPosition;
    public Transform DefeatPosition;

    public void Start()
    {
        foreach (List<Transform> path in paths)
        {
            path.Add(DoorPosition);
            path.Add(DefeatPosition);
        }
    }

    public Queue<Transform> GetRandomPath()
    {
        if (paths.Count == 0)
        {
            Debug.LogError("No paths set");
            return null;
        }
        return new Queue<Transform>(paths[Random.Range(0, paths.Count)]);
    }
}
