using UnityEngine;

[CreateAssetMenu(fileName = "YeniKarakterVerisi", menuName = "Stats/CharachterStats")]
public class CharacterStats : ScriptableObject
{
    public string karakterAdi;
    public int maksCan;
    public float hareketHizi;
    public int saldiriGucu;
}