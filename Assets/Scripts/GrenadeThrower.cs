using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InfimaGames.LowPolyShooterPack;

public class GrenadeThrower : MonoBehaviour
{
    public Image grenadeImage;
    public float throwForce = 20f;
    public GameObject grenadePrefab;
    [SerializeField] private LineRenderer LineRenderer;
    [SerializeField] private Transform ReleasePosition;
    [SerializeField] private Character Character;

    [Header("Display Controls")]
    [SerializeField]
    [Range(10, 100)]
    private int LinePoints = 25;
    [SerializeField]
    [Range(0.01f, 0.25f)]
    private float TimeBetweenPoints = 0.1f;

    private LayerMask GrenadeCollisionMask;

    float delay = 5f;
    float countDelay;
    // Update is called once per frame
    void Awake()
    {
        int grenadeLayer = grenadePrefab.gameObject.layer;
        for(int i = 0; i < 32; i++)
        {
            if(!Physics.GetIgnoreLayerCollision(grenadeLayer, i))
            {
                GrenadeCollisionMask |= 1 << i;
            }
        }
    }
    void Start()
    {
        grenadeImage.fillAmount = 1;
        countDelay = 0;
    }
    void Update()
    {
        if (countDelay <= 0)
        {
            if (Input.GetKey(KeyCode.G) && Character.CanThrowGrenade())
            {
                Character.grenadeThrowing = true;
                DrawProjection();
            }
            else
            {
                LineRenderer.enabled = false;
            }
            if (Input.GetKeyUp(KeyCode.G) && Character.CanThrowGrenade())
            {
                countDelay = delay;
                Character.grenadeThrowing = false;
                ThrowGrenade();
                grenadeImage.fillAmount = 0;
            }
        }
        else
        {
            countDelay -= Time.deltaTime;
            grenadeImage.fillAmount += 1 / delay * Time.deltaTime;
        }
    }
    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, ReleasePosition.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.VelocityChange);
    }
    void DrawProjection()
    {
        LineRenderer.enabled = true;
        LineRenderer.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints) + 1;
        Vector3 startPosition = ReleasePosition.position;
        Vector3 startVelocity = throwForce * Camera.main.transform.forward / 1;
        int i = 0;
        LineRenderer.SetPosition(i, startPosition);
        for(float time = 0; time < LinePoints; time += TimeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);

            LineRenderer.SetPosition(i, point);

            Vector3 lastPosition = LineRenderer.GetPosition(i - 1);

            if(Physics.Raycast(lastPosition, (point - lastPosition).normalized, out RaycastHit hit, (point - lastPosition).magnitude, GrenadeCollisionMask))
            {
                LineRenderer.SetPosition(i, hit.point);
                LineRenderer.positionCount = i + 1;
                return;
            }
        }
    }
}
