using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TdWaypointProvider : MonoBehaviour
{
    [SerializeField]
    private List<Transform> waypoints;

    private static TdWaypointProvider instance;
    public static TdWaypointProvider Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("There are no waypoints!");
        }  
    }

    public Transform GetNextWaypoint(Transform waypoint)
    {
        if (waypoint == null)
        {
            Debug.Log("Retruning first waypoint");
            return waypoints.First();
        }
        int index = waypoints.IndexOf(waypoint);
        index++;

        if(index < waypoints.Count)
        {
            Debug.Log("Returning next waypoint");
            return waypoints[index];
        }
        Debug.Log("Returning null");
        return null;
    }
}
