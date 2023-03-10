// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine.
    /// </summary>
    public class Magazine : MagazineBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]
        
        [Tooltip("Total Ammunition.")]
        [SerializeField]
        private int ammunitionTotal = 20;

        [Tooltip("Magazine ammo")]
        [SerializeField]
        private int Ammo = 10;
        [Header("Interface")]

        [Tooltip("Interface Sprite.")]
        [SerializeField]
        private Sprite sprite;

        #endregion

        #region GETTERS

        /// <summary>
        /// Ammunition Total.
        /// </summary>
        /// public override int GetAmmunitionTotal() => ammunitionTotal;
        public override int GetAmmunitionTotal() => ammunitionTotal;
        public override int GetAmmo() => Ammo;
        public override void SetAmmunitionTotal(int value) { ammunitionTotal = value; }
        /// <summary>
        /// Sprite.
        /// </summary>
        public override Sprite GetSprite() => sprite;

        #endregion
    }
}