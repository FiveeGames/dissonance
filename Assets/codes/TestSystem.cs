using UnityEngine;

public class TestSystem : MonoBehaviour
{
    public PatientSpawner spawner;
    public DiagnosisManager diagnosisManager;
    public Doctor doctor;

    Patient currentPatient;

    void Start()
    {
        
            Debug.Log("TEST SYSTEM STARTED");
        
        spawner.SpawnPatient();
        currentPatient = FindObjectOfType<Patient>();

        Debug.Log("Spawned diseases count: " + currentPatient.diseases.Count);

        // 5 soru soruyormuþ gibi yap
        for (int i = 0; i < 5; i++)
        {
            currentPatient.RevealRandomSymptom();
        }

        var symptoms = currentPatient.GetRevealedSymptoms();

        Debug.Log("Revealed Symptoms:");
        foreach (var s in symptoms)
        {
            Debug.Log(s);
        }

        // Teþhis test
        bool result = diagnosisManager.EvaluateDiagnosis(
            currentPatient,
            currentPatient.diseases[0],
            doctor.level
        );

        Debug.Log("Diagnosis Result: " + result);
    }
}