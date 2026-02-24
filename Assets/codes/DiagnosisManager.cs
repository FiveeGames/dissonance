using UnityEngine;
using System.Collections.Generic;

public class DiagnosisManager : MonoBehaviour
{
    public float requiredAccuracy = 0.6f;

    public bool EvaluateDiagnosis(Patient patient, DiseaseData selectedDisease, int doctorLevel)
    {
        List<SymptomType> revealed = patient.GetRevealedSymptoms();
        List<SymptomType> actual = selectedDisease.trueSymptoms;

        int matchCount = 0;

        foreach (var symptom in revealed)
        {
            if (actual.Contains(symptom))
                matchCount++;
        }

        float accuracy = actual.Count > 0 ? (float)matchCount / actual.Count : 0f;

        // Doctor bonus
        accuracy += doctorLevel * 0.1f;

        Debug.Log("Final Accuracy: " + accuracy);

        return accuracy >= requiredAccuracy;
    }
}