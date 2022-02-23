using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiManager : MonoBehaviour
{
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] public float fov = 90f;
    [SerializeField] public float viewDistance = 50f;
    public Vector3 dir;

    [SerializeField] private GameObject ForwardDirObj;

    [HideInInspector] public FieldOfView fieldOfView;

    public AIDestinationSetter DestSetter;
    public Ai_Spotted Spotted;
    public AI_Detection_Signal DetectionSignal;

    public GameObject Player;
    public GameObject PlayerLastSeen;

    [Range(0,1)]
    public float DetectionLevel;

    public bool Chasing;

    private bool LineofSight;

    private void Start()
    {
        fieldOfView = Instantiate(pfFieldOfView, null).GetComponent<FieldOfView>();
        fieldOfView.AiManager = gameObject.GetComponent<AiManager>();
        Spotted = fieldOfView.GetComponent<Ai_Spotted>();
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDistance(viewDistance);
    }

    public void Update()
    {
        if(DetectionLevel > 1)
        {
            DetectionLevel = 1;
        }
        else if(DetectionLevel < 0)
        {
            DetectionLevel = 0;
        }

        if(Chasing == true)
        {
            DestSetter.target = PlayerLastSeen.transform;
            PlayerLastSeen.transform.position = Player.transform.position;
        }

        if (fieldOfView != null)
        {
            fieldOfView.SetOrigin(transform.position);
            fieldOfView.SetAimDirection(GetAimDir());
        }
    }

    public void Spotter()
    {
        DestSetter.target = PlayerLastSeen.transform;
        Chasing = true;
    }

    public Vector3 GetAimDir()
    {
        Vector3 dir = (ForwardDirObj.transform.position - gameObject.transform.position).normalized;
        return dir;
    }
}
