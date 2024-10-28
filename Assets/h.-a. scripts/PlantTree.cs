using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Serializable class to hold tag-prefab pairs
[System.Serializable]
public class TaggedPrefab
{
    public string tag;
    public GameObject prefab;
}

public class PlantTree : MonoBehaviour
{
    // List of tagged prefabs to be assigned in the Inspector
    public List<TaggedPrefab> taggedPrefabs;

    // Dictionary to track instantiation status for each tag
    private Dictionary<string, bool> instantiatedTags = new Dictionary<string, bool>();

    private void Start()
    {
        // Initialize the dictionary to track instantiation status by tag
        foreach (TaggedPrefab item in taggedPrefabs)
        {
            if (!instantiatedTags.ContainsKey(item.tag))
            {
                instantiatedTags[item.tag] = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        // Loop through taggedPrefabs and check if the tag matches and hasn't been instantiated
        foreach (TaggedPrefab item in taggedPrefabs)
        {
            if (collider.gameObject.CompareTag(item.tag) && !instantiatedTags[item.tag])
            {
                // Set as instantiated
                instantiatedTags[item.tag] = true;

                // Destroy the seed object
                Destroy(collider.gameObject);

                // Instantiate the prefab at the collision position
                PlantPrefabAtPosition(item.prefab, collider.transform.position);

                // Break the loop after instantiation
                break;
            }
        }
    }

    // Method to instantiate the prefab at the specified position
    private void PlantPrefabAtPosition(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }
}