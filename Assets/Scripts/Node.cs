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

    public string nodeTag;

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

        if (turret != null)
            return;

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);

        if(tag == "Unreachable")
        {
            turret.tag = tag;
        }

    }

    void OnMouseOver()
    {
        if (turret != null)
            return;

        if (!buildManager.turretSelected)
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
