using UnityEngine;

[System.Serializable]
public class DiseaseInstance
{
    public DiseaseData data;

    public int severityLevel; // 1-5
    public float instability; // 0-100
    public bool treatedCorrectly;

    public DiseaseInstance(DiseaseData diseaseData)
    {
        data = diseaseData;
        severityLevel = 1;
        instability = 10f;
        treatedCorrectly = false;
    }

    public void ProgressDisease()
    {
        if (!treatedCorrectly)
        {
            instability += 10f;

            if (instability > 50f)
                severityLevel++;
        }
        else
        {
            instability -= 5f;
            if (instability < 0f)
                instability = 0f;
        }
    }
}