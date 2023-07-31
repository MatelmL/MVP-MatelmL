//This script is attached automatically to each Object caught in Tornado

using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Spells {
        
    public interface ICaught 
    {
        public void OnCaught();
        public Rigidbody GetRigidbody();
    }
}