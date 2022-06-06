using UnityEngine;

public class ValidationTest : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Test validation");
        IronSource.Agent.validateIntegration();
    }
}
