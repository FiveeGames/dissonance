using UnityEngine;

public class HospitalSecurity : MonoBehaviour
{
    public int securityLevel = 0;

    public void AddSecurity(int amount)
    {
        securityLevel += amount;
    }
}