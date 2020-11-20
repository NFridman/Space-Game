using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Background element prefabs")]
    [SerializeField] private List<GameObject> m_Prefabs;
    [Space]
    [Tooltip("Background objects parent")]
    [SerializeField] private Transform m_Container;
    [Tooltip("Minimal background element size")]
    [SerializeField] private float m_elementMinSize;
    [Tooltip("Maximum background element size")]
    [SerializeField] private float m_elementMaxSize;

    [Tooltip("Prefabs count in background")]
    [SerializeField] private int m_NumInstances;
    [Tooltip("Background sphere radius")]
    [SerializeField] [Range(0, 5)] private float m_Radius;

    [Header("Development Settings")]
    [SerializeField] private bool showDebugLogs;

    // TODO: scaling
    // Generator seed

    private void Start()
    {
        Generate();
    }

    /// <summary>
    /// Generate background
    /// </summary>
    private void Generate()
    {
        for(int i = 0; i< m_NumInstances; i++)
        {
            // Generate random prefab id
            var randomPrefabIndex = UnityEngine.Random.Range(0, m_Prefabs.Count);

            if(showDebugLogs) Debug.Log("{<color=green>GameLog</color>} => [BackgroundGenerator] - (<color=yellow>Generate</color>) -> Random prefab index: " + randomPrefabIndex);

            // Instance prefab
            var quad = Instantiate(m_Prefabs[randomPrefabIndex], m_Container);

            // Set background element postion
            quad.transform.position = m_Container.position + UnityEngine.Random.onUnitSphere * m_Radius;
            quad.transform.LookAt(m_Container);
            quad.transform.forward = -quad.transform.forward;

            // Set background element rotation
            quad.transform.Rotate(Vector3.forward * UnityEngine.Random.Range(-180, 180), Space.Self);

            // Generate random scale
            var randomScale  = UnityEngine.Random.Range(m_elementMinSize, m_elementMaxSize);

            // Set random scale
            quad.transform.localScale = new Vector3(randomScale, randomScale, 1);
        }
    }
}
