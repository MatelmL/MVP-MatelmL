using System;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using System.Collections;
namespace Spells
{
    public class Tornado : MonoBehaviour, ISpellInit
    {
        SOSpell spellData;

        private Collider _collider;
        public float RotationSpeed;
        private List<ICaught> _caughts = new();
        public float Duration;
        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
        }

        public void Init(SOSpell _spellData)
        {
            spellData = _spellData;
        }

        IEnumerator Lifetime()
        {
            yield return new WaitForSeconds(Duration);
            if (gameObject.activeSelf) gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            StartCoroutine(Lifetime());
        }

        private void OnTriggerEnter(Collider other)
        {
            var caught = other.GetComponent<ICaught>();
            caught?.OnCaught(onDeathCallback: () => _caughts.Remove(caught));
            if(caught != null)_caughts.Add(caught);
        }

        private void FixedUpdate()
        {
            foreach (var caught in _caughts)
            {
                var rb = caught.GetRigidbody();
                rb?.AddForce(Vector3.up * spellData.force, ForceMode.Acceleration);
                rb?.transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
            }
        }
    }
}
