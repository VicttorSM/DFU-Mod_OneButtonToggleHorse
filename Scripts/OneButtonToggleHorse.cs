// Project:         OneButtonToggleHorse mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2024 VicttorSM
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          VicttorSM
// Created On: 	    03/11/2024, 03:00 AM
// Last Edit:		03/11/2024, 03:00 AM
// Version:			1.00
// Special Thanks:  
// Modifier:			

using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;

namespace OneButtonToggleHorse
{
    public class OneButtonToggleHorse : MonoBehaviour
    {
        static OneButtonToggleHorse instance;

        public static OneButtonToggleHorse Instance
        {
            get { return instance ?? (instance = FindObjectOfType<OneButtonToggleHorse>()); }
        }

        static Mod mod;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            instance = new GameObject("OneButtonToggleHorse").AddComponent<OneButtonToggleHorse>(); // Add script to the scene.

            mod.IsReady = true;
        }

        private void Start()
        {
            Debug.Log("Begin mod init: One Button Toggle Horse");

            // Do stuff

            Debug.Log("Finished mod init: One Button Toggle Horse");
        }
    }
}
