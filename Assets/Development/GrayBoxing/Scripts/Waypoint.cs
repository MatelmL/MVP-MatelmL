using UnityEngine;

namespace GrayBoxing
{
    [RequireComponent(typeof(BoxCollider))]
    public class Waypoint : MonoBehaviour
    {
        public Transform newDestination;
    }
}
