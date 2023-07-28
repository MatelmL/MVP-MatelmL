using System.Collections.Generic;
using UnityEngine;

public class Paths : MonoBehaviour
{
    //singleton
    public static Paths Instance;
    [SerializeField] List<PathScript> paths;
    public Transform DoorPosition;
    public Transform DefeatPosition;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Paths already exists");
        }

        foreach (PathScript pathScript in paths)
        {
            pathScript.path.Add(DoorPosition);
            pathScript.path.Add(DefeatPosition);
        }
    }

    public Queue<Transform> GetRandomPath()
    {
        if (paths.Count == 0)
        {
            return null;
        }
        return new Queue<Transform>(paths[Random.Range(0, paths.Count)].path);
    }
}
