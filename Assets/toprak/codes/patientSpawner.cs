using UnityEngine;
using System.Collections.Generic;

public class PatientSpawner : MonoBehaviour
{
    public GameObject patientPrefab;
    public List<DiseaseData> possibleDiseases;

    [Range(0f, 1f)]
    public float comorbidityChance = 0.2f;

    public void SpawnPatient()
    {
        GameObject obj = Instantiate(patientPrefab, transform.position, Quaternion.identity);
        Patient patient = obj.GetComponent<Patient>();

        // Primary disease
        DiseaseData first = possibleDiseases[Random.Range(0, possibleDiseases.Count)];
        patient.diseases.Add(new DiseaseInstance(first));

        // Comorbidity
        if (Random.value < comorbidityChance)
        {
            DiseaseData second = possibleDiseases[Random.Range(0, possibleDiseases.Count)];
            if (second != first)
                patient.diseases.Add(new DiseaseInstance(second));
        }
    }
}