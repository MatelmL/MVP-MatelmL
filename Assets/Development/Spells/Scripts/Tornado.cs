using System;
using UnityEditor.UIElements;
using UnityEngine;
namespace Spells
{
    public class Tornado : MonoBehaviour, ISpellInit
    {
        SOSpell spellData;

        private Collider _collider;
        public float RotationSpeed;
        private ICaught[] _caughts;
        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
        }

        public void Init(SOSpell _spellData)
        {
            spellData = _spellData;
        }
        private void OnTriggerEnter(Collider other)
        {
            var caught = other.GetComponent<ICaught>();
            if (caught == null) return;
            var takeDamage = other.GetComponent<ITakeDamage>();
            takeDamage?.TakeDamage(1);
            caught.OnCaught();
        }

        private void FixedUpdate()
        {
            foreach (var caught in _caughts)
            {
                var rb = caught.GetRigidbody();
                rb.AddForce(Vector3.up * spellData.force, ForceMode.Acceleration);
                rb.transform.RotateAround(transform.position, Vector3.up, 100 * Time.deltaTime);
            }
        }
    }
}
