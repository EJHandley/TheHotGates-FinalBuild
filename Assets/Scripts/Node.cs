using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("On Hover")]
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    [Header("Optional")]
    public GameObject turret;

    public GameObject turretPreview;
    public bool turretPreviewed;

    public Vector3 positionOffset;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("NOPE!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseOver()
    {
        if (turret != null)
            return;

        if (!turretPreviewed)
        {
            turretPreview = Instantiate(buildManager.turretToBuild.preview, GetBuildPosition(), Quaternion.identity);
            turretPreviewed = true;
        }

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        Destroy(turretPreview);
        turretPreviewed = false;
        rend.material.color = startColor;
    }
}
