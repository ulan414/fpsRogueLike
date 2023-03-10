// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;



    /// <summary>
    /// Magazine Behaviour.
    /// </summary>
    public abstract class magazineBehaviorBot : MonoBehaviour
    {
        #region GETTERS


        #endregion
        public abstract int GetAmmunitionTotal();
        public abstract int GetAmmo();
        public abstract void SetAmmunitionTotal(int value);
        /// <summary>
        /// Returns the Sprite used on the Character's Interface.
        /// </summary>
        public abstract Sprite GetSprite();
    }
