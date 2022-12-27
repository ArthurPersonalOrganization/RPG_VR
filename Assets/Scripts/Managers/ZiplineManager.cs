using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Scripts.Managers
{
    public class ZiplineManager : MonoBehaviour
    {
        [SerializeField]
        private Transform playerBody;

        [SerializeField]
        private Transform ziplineAttachment;

        [SerializeField]
        private Transform realPlayerAttachment;

        [SerializeField]
        private Transform StartTransform;

        [SerializeField]
        private Transform EndTransform;

        [SerializeField]
        private ContinuousMoveProviderBase moveContinousProvider;

        [SerializeField]
        private SnapTurnProviderBase turnProviderBase;

        [SerializeField]
        private float speed;

        [SerializeField]
        private Transform PlayerOriginalParent;

        [Header("just for testing")]
        public Transform simulatedStartPoint;

        public Transform simulatedEndPoint;
        private Vector3 realStartAttachmentPosition;
        private Vector3 realEndAttachmentPosition;
        private bool attachedPlayer = false;
        private bool ziplineAtTheStart = false;
        private bool isTraveling = false;

        private void Start()
        {
            realStartAttachmentPosition = new Vector3(StartTransform.position.x, StartTransform.position.y - 1, StartTransform.position.z);
            realEndAttachmentPosition = new Vector3(EndTransform.position.x, EndTransform.position.y - 1, EndTransform.position.z);
            realPlayerAttachment.transform.position = realStartAttachmentPosition;
            ziplineAttachment.transform.position = StartTransform.position;
        }

        private void Update()
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                Debug.Log("going down");
                GoingDown();
            }

            if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                Debug.Log("going up");
                GoingUp();
            }
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                StartCoroutine(SimulateGrabbing());
            }
        }

        private IEnumerator SimulateGrabbing()
        {
            //simulation of going down the zipline once
            //move the player to the position

            playerBody.transform.localPosition = simulatedStartPoint.transform.localPosition;
            //attach the player GO to the ziplineAttachment
            playerBody.transform.SetParent(realPlayerAttachment);

            yield return new WaitForSeconds(1f);
            GrabZipline();
            yield return new WaitForEndOfFrame();
            //move it
            if (attachedPlayer)
            {
                yield return StartCoroutine(MoveZipline(StartTransform.position, EndTransform.position, realStartAttachmentPosition, realEndAttachmentPosition));
            }
            UnGrabZipline();
        }

        public void GrabZipline()
        {
            //Deactivate xr movement while airborne
            //attach the player body to the zipline

            if (ziplineAtTheStart && !isTraveling)
            {
                GoingDown();
            }
            else if (!ziplineAtTheStart && !isTraveling)
            {
                GoingUp();
            }

            moveContinousProvider.enabled = false;
            turnProviderBase.enabled = false;
            attachedPlayer = true;
        }

        public void UnGrabZipline()
        {
            //activate the xr movement once player lands
            //detach the player body from the zipline
            playerBody.transform.SetParent(PlayerOriginalParent);
            moveContinousProvider.enabled = true;
            turnProviderBase.enabled = true;
            attachedPlayer = false;
        }

        public void GoingDown()
        {
            if (ziplineAttachment.transform.position == StartTransform.position &&
                realPlayerAttachment.transform.position == realStartAttachmentPosition)
            {
                StartCoroutine(MoveZipline(StartTransform.position, EndTransform.position, realStartAttachmentPosition, realEndAttachmentPosition));
            }
        }

        public void GoingUp()
        {
            if (ziplineAttachment.transform.position == EndTransform.position &&
                realPlayerAttachment.transform.position == realEndAttachmentPosition)
            {
                StartCoroutine(MoveZipline(EndTransform.position, StartTransform.position, realEndAttachmentPosition, realStartAttachmentPosition));
            }
        }

        private IEnumerator MoveZipline(Vector3 a, Vector3 b, Vector3 rs, Vector3 re)
        {
            isTraveling = true;
            float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
            float t = 0;

            while (t <= 1.0f)
            {
                t += step;
                ziplineAttachment.transform.position = Vector3.Lerp(a, b, t);
                realPlayerAttachment.transform.position = Vector3.Lerp(rs, re, t);
                yield return new WaitForFixedUpdate();
            }
            ziplineAttachment.transform.position = b;
            realPlayerAttachment.transform.position = re;
            isTraveling = false;
        }

        /*
        private IEnumerator MoveGrabberRoutine(float start, float end)
        {
            float timer = Time.deltaTime;
            float pos = start;
            Debug.Log("Init pos " + pos);
            while (pos > end)
            {
                pos -= speed * Time.deltaTime;
                Debug.Log("zipline x " + pos);
                ziplineAttachment.transform.localPosition -= new Vector3(speed * Time.deltaTime, 0, 0);

                yield return new WaitForEndOfFrame();
            }
            Debug.Log("end of line");
            ziplineAttachment.transform.localPosition = new Vector3(end, 0, 0);
            yield return null;
        }

        private IEnumerator ReturnGrabberRoutine(float start, float end)
        {
            float timer = Time.deltaTime;
            float pos = start;
            Debug.Log("Init pos " + pos);
            while (pos < end)
            {
                pos += speed * Time.deltaTime;
                Debug.Log("zipline x " + pos);
                ziplineAttachment.transform.localPosition += new Vector3(speed * Time.deltaTime, 0, 0);

                yield return new WaitForEndOfFrame();
            }
            Debug.Log("end of line");
            ziplineAttachment.transform.localPosition = new Vector3(end, 0, 0);
            yield return null;
        }
        */
    }
}