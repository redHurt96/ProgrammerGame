using UnityEngine;

public class ValidationTest : MonoBehaviour
{
    [ContextMenu("Test")]
    private void Start()
    {
        IronSource.Agent.validateIntegration();
    }
}
