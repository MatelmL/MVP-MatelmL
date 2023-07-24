using UnityEngine;
using UnityEngine.Events;

namespace Goblin
{
    public enum GoblinState
    {
        Attacking,
        Moving,
        Dying,
    }

    public class EnemyState : MonoBehaviour
    {
        public GoblinState currentState;

        public UnityEvent onAttackStart;
        public UnityEvent onAttackEnd;
        
        public UnityEvent onMoveStart;
        public UnityEvent onMoveEnd;
       
        public UnityEvent onDieStart;
        public UnityEvent onDieEnd;
        public void StartAattacking()
        {
            ExitState();
            currentState = GoblinState.Attacking;
            onAttackStart.Invoke();
        }
        public void StartMoving()
        {
            ExitState();
            currentState = GoblinState.Moving;
            onMoveStart.Invoke();
        }
        public void StartDying()
        {
            ExitState();
            currentState = GoblinState.Dying;
            onDieStart.Invoke();
        }
        
        public void ExitState()
        {
            switch (currentState)
            {
                case GoblinState.Attacking: onAttackEnd.Invoke();
                    break;
                case GoblinState.Moving: onMoveEnd.Invoke();
                    break;
                case GoblinState.Dying: onDieEnd.Invoke();
                    break;
            }
        }
    }
}
