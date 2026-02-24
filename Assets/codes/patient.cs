using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Patient : MonoBehaviour
{
    [Header("Assigned Diseases")]
    public List<DiseaseData> diseases = new();

    [Header("State")]
    public PatientState currentState;

    private NavMeshAgent agent;
    private List<SymptomType> revealedSymptoms = new();

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentState = PatientState.Waiting;
    }

    #region Symptom System

    public void RevealRandomSymptom()
    {
        foreach (var disease in diseases)
        {
            // TRUE symptom
            if (Random.value < disease.baseRevealChance && disease.trueSymptoms.Count > 0)
            {
                AddSymptom(disease.trueSymptoms[Random.Range(0, disease.trueSymptoms.Count)]);
            }

            // FAKE symptom
            if (Random.value < 0.15f && disease.possibleFakeSymptoms.Count > 0)
            {
                AddSymptom(disease.possibleFakeSymptoms[Random.Range(0, disease.possibleFakeSymptoms.Count)]);
            }
        }
    }

    public void RevealHiddenSymptom()
    {
        foreach (var disease in diseases)
        {
            if (disease.hiddenSymptoms.Count > 0)
            {
                AddSymptom(disease.hiddenSymptoms[Random.Range(0, disease.hiddenSymptoms.Count)]);
            }
        }
    }

    void AddSymptom(SymptomType symptom)
    {
        if (!revealedSymptoms.Contains(symptom))
            revealedSymptoms.Add(symptom);
    }

    public List<SymptomType> GetRevealedSymptoms()
    {
        return revealedSymptoms;
    }

    #endregion

    #region State Logic

    public void ChangeState(PatientState newState)
    {
        currentState = newState;
    }

    public void TryEscape(int securityLevel)
    {
        float escapeChance = 0.4f - (securityLevel * 0.05f);

        if (Random.value < escapeChance)
        {
            currentState = PatientState.Escaping;
            Debug.Log("Patient is escaping!");
        }
    }

    #endregion
}