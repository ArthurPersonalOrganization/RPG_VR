using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Scripts.Player
{
    public class ClimbableInteractable : XRBaseInteractable
    {
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            Debug.Log("args here " + args.interactorObject);
            XRBaseInteractor interactor = args.interactor;
            Debug.Log("interactor " + interactor.GetType());
            base.OnSelectEntered(args);

            if (interactor is XRDirectInteractor)
            {
                Debug.Log("xrdirect interactor here");

                var comp = interactor.GetComponentsInParent<ActionBasedController>();
                Debug.Log(comp.GetType().Name);
                foreach (var c in comp)
                {
                    Debug.Log("comp " + c.GetType());
                }

                Climber.climbingHand = interactor.GetComponentInParent<ActionBasedController>();
            }
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            XRBaseInteractor interactor = args.interactor;
            base.OnSelectExited(args);

            if (Climber.climbingHand && Climber.climbingHand.name == interactor.name)
            {
                Climber.climbingHand = null;
            }
        }
    }
}