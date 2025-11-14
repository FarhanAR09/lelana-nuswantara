using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractibleDetector : MonoBehaviour
{
    List<Interactible> collidedInteractibles = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactible interactible) && !collidedInteractibles.Contains(interactible))
        {
            collidedInteractibles.Add(interactible);
            interactible.ChangeIconVisibility(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Interactible interactible) && collidedInteractibles.Contains(interactible))
        {
            collidedInteractibles.Remove(interactible);
            interactible.ChangeIconVisibility(false);
        }
    }

    public void TryInteract()
    {
        if (collidedInteractibles.Count > 0)
        {
            Interactible closest = null;
            foreach (Interactible interactible in collidedInteractibles)
            {
                if (closest == null)
                {
                    closest = interactible;
                }
                else if (Vector2.Distance(interactible.transform.position, transform.position) < Vector2.Distance(closest.transform.position, transform.position))
                {
                    closest = interactible;
                }
            }
            closest.Interact();
        }
    }
}
