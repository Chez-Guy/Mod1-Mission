using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SlingshotBand : MonoBehaviour
{
    LineRenderer line1;
    LineRenderer line2;
    Transform projectile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line1 = transform.GetChild(0).GetComponent<LineRenderer>();
        line2 = transform.GetChild(1).GetComponent<LineRenderer>();
    }
    
    public void ToggleLine(Transform proj = null, bool i = false)
    {
        if (proj) {projectile = proj;}
        line1.enabled = i;
        line2.enabled = i;
    }

    void SetLinePosition(Vector3 vector)
    {
        line1.SetPosition(1, vector);
        line2.SetPosition(1, vector);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (line1.enabled)
        {
            SetLinePosition(projectile.position);
        } else
        {
            ToggleLine();
        }
    }
}
