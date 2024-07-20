using UnityEngine;

namespace GameEnum.Templates
{
    public interface IItemMovable
    {
        bool OnPickup(Transform handTransform);
        void OnPlace(Transform newParentTransform);

        void OnRemoveItemFromPlayer();

        void OnThrow();
    }
}