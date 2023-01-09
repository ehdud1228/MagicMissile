using System;
using UnityEngine;

namespace Pawns.Player
{
    public class AddForceAddOn : IAddOn
    {
        public enum ForceType
        {
            FixedForce, 
            DynamicForce,
            ToFixedPosition,
            ToDynamicPosition,
        }
        private ForceType forceType;
        
        private Vector2 fixedForce;
        private Vector2 dynamicForce;
        private Vector2 fixedPosition;
        private Transform dynamicTransform;
        
        private readonly float forceTypeMultiplier = 1f;
        
        private float forcePower;


        public AddForceAddOn(ForceType forceType, float forcePower)
        {
            this.forceType = forceType;
            this.forcePower = forcePower;
            switch (forceType)
            {
                case ForceType.FixedForce:
                    forceTypeMultiplier = 1f;
                    break;
                case ForceType.DynamicForce:
                    // ToDo: Implement
                    break;
                case ForceType.ToFixedPosition:
                    forceTypeMultiplier = 2f;
                    break;
                case ForceType.ToDynamicPosition:
                    forceTypeMultiplier = 3f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(forceType), forceType, null);
            }
        }
        
        public void SetFixedForce(Vector2 force)
        {
            fixedForce = force;
        }
        
        public void SetFixedPosition(Vector2 position)
        {
            fixedPosition = position;
        }
        
        public void SetDynamicTransform(Transform transform)
        {
            dynamicTransform = transform;
        }
        
        public void SetForcePower(float forcePower)
        {
            this.forcePower = forcePower;
        }
       
        public float ControlMissile(Missile missile)
        {
            switch (forceType)
            {
                case ForceType.FixedForce:
                    AddFixedForce(missile);
                    break;
                case ForceType.DynamicForce:
                    // ToDo: Implement
                    break;
                case ForceType.ToFixedPosition:
                    AddForceToFixedPosition(missile);
                    break;
                case ForceType.ToDynamicPosition:
                    AddForceToDynamicPosition(missile);
                    break;
            }
            return forcePower * forceTypeMultiplier;
        }
        
        private void AddFixedForce(Missile missile)
        {
            missile.rb.AddForce(fixedForce.normalized * forcePower);
        }

        private void AddDynamicForce(Missile missile)
        {
            // ToDo: Implement
        }
        
        private void AddForceToFixedPosition(Missile missile)
        {
            var direction = fixedPosition - (Vector2) missile.transform.position;
            missile.rb.AddForce(direction.normalized * forcePower);
        }
        
        private void AddForceToDynamicPosition(Missile missile)
        {
            var direction = dynamicTransform.position - missile.transform.position;
            missile.rb.AddForce(direction.normalized * forcePower);
        }
    }
}