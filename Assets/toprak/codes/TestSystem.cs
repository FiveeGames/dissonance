using UnityEngine;

public class TestSystem : MonoBehaviour
{
    public PatientSpawner spawner;
    public DiagnosisManager diagnosisManager;
    public Doctor doctor;

    Patient currentPatient;

    void Start()
    {
        foreach (var d in currentPatient.diseases)
        {
            Debug.Log("Disease: " + d.data.diseaseName);
            Debug.Log("Severity: " + d.severityLevel);
            Debug.Log("Instability: " + d.instability);
        }

        currentPatient.RevealRandomSymptom();

        Debug.Log("Revealed Symptoms:");
        foreach (var s in currentPatient.revealedSymptoms)
        {
            Debug.Log(s);
        }
    }

    void Awake()
    {
        if (currentPatient == null)
            currentPatient = Object.FindFirstObjectByType<Patient>();
    }
}