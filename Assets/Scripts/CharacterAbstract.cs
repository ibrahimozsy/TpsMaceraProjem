using UnityEngine;
using System;
using UnityEngine.AI;

public abstract class CharacterAbstract : MonoBehaviour,IInteractable
{
    [Header("Ortak Veriler")]

    [Header("Bilesenler")]
    protected NavMeshAgent agent;
    public void moveTo(Vector3 target)
    {
        if (agent == null) return;
        agent.SetDestination(target);
    }

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public virtual void OnLeftClick()
    {
        GameEventManager.OnCharacterSelected.Invoke(this);
    }
}
