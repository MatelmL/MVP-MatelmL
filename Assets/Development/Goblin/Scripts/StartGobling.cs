using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ResetOnGameRestart))]
public class StartGobling : MonoBehaviour, ITakeDamage, IAddForce, IReset, ICaught
{

    public UnityEvent OnStartGoblingDie;
    public UnityEvent OnStartGoblingEnable;
    public UnityEvent OnStartGoblingTween;
    public Action OnStartGoblingTweenAction;
    public float health { get; set; }

    public Rigidbody chestRb;

    private Transform startPosition;

    private void Awake()
    {
        startPosition = transform;
    }
    public void TakeDamage(float damageAmount)
    {
        OnStartGoblingDie?.Invoke();
    }
    public void AddForce(float magnitude, Transform origin, float radius)
    {
        chestRb.AddForce(((transform.position - origin.position).normalized + Vector3.up) * magnitude, ForceMode.Impulse);
    }

    public void InvokeDie(float time)
    {
        Invoke(nameof(Die), time);
    }
    private void Die()
    {
        //GetComponent<Ragdoll>().SetEnabled(false);
        transform.GetChild(1).LeanScale(Vector3.zero, 1f).setOnComplete(Disable).setOnStart(TweenStart);
    }

    private void TweenStart()
    {
        OnStartGoblingTween?.Invoke();
        OnStartGoblingTweenAction?.Invoke();
    }

    private void Disable()
    {
        WaveManager.instance.StartWave();
        SoundsManager.instance.PlayShofar();
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(0);
        }
    }

    public void Reset()
    {
        OnStartGoblingEnable?.Invoke();
        transform.GetChild(1).LeanScale(Vector3.one, 1f);
        transform.position = startPosition.position;
        gameObject.SetActive(true);
    }

    public void OnCaught(Action onDeathCallback)
    {
        OnStartGoblingTweenAction += onDeathCallback;
        TakeDamage(0);
    }

    public Rigidbody GetRigidbody()
    {
        return chestRb;
    }
}
