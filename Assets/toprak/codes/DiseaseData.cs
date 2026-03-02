using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDisease", menuName = "Hospital/Disease")]
public class DiseaseData : ScriptableObject
{
    public string diseaseName;

    [Header("Core Symptoms")]
    public List<SymptomType> trueSymptoms = new();

    [Header("Fake Symptoms")]
    public List<SymptomType> possibleFakeSymptoms = new();

    [Header("Hidden Symptoms")]
    public List<SymptomType> hiddenSymptoms = new();

    [Range(0f, 1f)]
    public float baseRevealChance = 0.4f;
}