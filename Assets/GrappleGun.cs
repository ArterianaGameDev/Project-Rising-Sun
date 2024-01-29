using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    private Vector3 currentGrapplePosition;

    public GameObject bullet;
    public float bulletSpeed = 10;




    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }
    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            StartGrapple();
        }
        else if(Input.GetMouseButtonUp(1)) {
            StopGrapple();
        }
        else if(Input.GetMouseButtonDown(0)) {
            FireBullet();
        }

    }
    private void LateUpdate() {
        DrawRope();
    }
    void StartGrapple() {
        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = 0.5f*distanceFromPoint;
            joint.minDistance = 0.1f*distanceFromPoint;

            joint.spring = 10f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
    }
    void DrawRope() {
        if(!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 20f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }
    public bool isGrappling() {
        return joint != null;
    }
    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }







    void FireBullet() {
        GameObject spawnBullet = Instantiate(bullet);
        spawnBullet.transform.position = gunTip.position;
        spawnBullet.GetComponent<Rigidbody>().velocity = bulletSpeed*gunTip.forward;
        Destroy(spawnBullet, 3);
    }

}
