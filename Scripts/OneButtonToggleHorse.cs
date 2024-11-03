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
using System;

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
        private KeyCode toggleKey = KeyCode.Mouse3;

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            instance = new GameObject("OneButtonToggleHorse").AddComponent<OneButtonToggleHorse>(); // Add script to the scene.

            mod.IsReady = true;
        }

        private void Update()
        {
            if (GameManager.Instance.StateManager.CurrentState == StateManager.StateTypes.Game)
            {
                if (Input.GetKeyDown(toggleKey))
                {
                    if (!GameManager.Instance.IsPlayerInside && GameManager.Instance.PlayerController.isGrounded)
                    {
                        GameManager.Instance.TransportManager.ToggleMount();
                    }
                }
            }
        }


        private void Start()
        {
            Debug.Log("Begin mod init: One Button Toggle Horse");

            //string keyName = "Mouse4";
            //var key = (KeyCode)Enum.Parse(typeof(KeyCode), keyName);

            //if (Enum.IsDefined(typeof(KeyCode), key))
            //{
            //    toggleKey = key;
            //    DaggerfallUI.AddHUDText($"New key to toggle mount: '{keyName}'");
            //}
            //else
            //{
            //    DaggerfallUI.AddHUDText($"New key to toggle mount could not be processed! Falling back to 'Mouse3'");
            //}

            Debug.Log("Finished mod init: One Button Toggle Horse");
        }
    }
}
