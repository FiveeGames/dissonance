using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Patient : MonoBehaviour
{
    [Header("Assigned Diseases")]
    public List<DiseaseInstance> diseases = new();

    public List<SymptomType> currentSymptoms = new List<SymptomType>();

    [Header("State")]
    public PatientState currentState;

    private NavMeshAgent agent;
    public List<SymptomType> revealedSymptoms = new();

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
            var data = disease.data;

            // TRUE symptom
            if (Random.value < data.baseRevealChance && data.trueSymptoms.Count > 0)
            {
                AddSymptom(data.trueSymptoms[Random.Range(0, data.trueSymptoms.Count)]);
            }

            // FAKE symptom
            if (Random.value < 0.15f && data.possibleFakeSymptoms.Count > 0)
            {
                AddSymptom(data.possibleFakeSymptoms[Random.Range(0, data.possibleFakeSymptoms.Count)]);
            }
        }
    }

    public void RevealHiddenSymptom()
    {
        foreach (var disease in diseases)
        {
            var data = disease.data;

            if (data.hiddenSymptoms.Count > 0)
            {
                AddSymptom(data.hiddenSymptoms[Random.Range(0, data.hiddenSymptoms.Count)]);
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