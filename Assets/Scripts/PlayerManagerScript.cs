using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManagerScript : MonoBehaviour
{
    public static PlayerManagerScript instance;

    public CharacterAbstract ActiveLeader;

    public List<CharacterAbstract> oyuncular = new List<CharacterAbstract>();

    private void OnEnable()
    {
        GameEventManager.OnCharacterSelected += HandleSelection;
    }
    private void OnDisable()
    {
        GameEventManager.OnCharacterSelected-= HandleSelection;
    }
    void HandleSelection(CharacterAbstract gelenKarakter)
    {
        ActiveLeader = gelenKarakter;
        
    }
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        ActiveLeader = oyuncular[0];
    }
}
