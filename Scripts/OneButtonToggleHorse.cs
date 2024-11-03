// Project:         OneButtonToggleHorse mod for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2024 VicttorSM
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          VicttorSM
// Created On: 	    03/11/2024, 03:00 AM
// Last Edit:		03/11/2024, 03:00 AM
// Version:			1.0.0
// Special Thanks:  
// Modifier:			

using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using System;
using UnityEngine.UIElements;

namespace OneButtonToggleHorse
{
    public class OneButtonToggleHorse : MonoBehaviour
    {
        static OneButtonToggleHorse instance;

        public static OneButtonToggleHorse Instance
        {
            get { return instance != null ? instance : (instance = FindObjectOfType<OneButtonToggleHorse>()); }
        }

        static Mod mod;
        private KeyCode toggleKey = KeyCode.G;

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
            // Captures the mod settings defined by the player
            var settings = mod.GetSettings();
            string keyName = settings.GetValue<string>("Options", "Toggle Horse Keycode");

            // Tries to parse the Key informed by the player to KeyCode
            Enum.TryParse<KeyCode>(keyName, out KeyCode newKeyCode);

            // If it fails to parse the first time, tries to parse again using uppercase on the keyName
            if (newKeyCode == KeyCode.None)
            {
                Enum.TryParse<KeyCode>(keyName.ToUpper(), out newKeyCode);
            }

            if (newKeyCode == KeyCode.None)
            {
                // Notifies player if it was not able to find the KeyCode
                DaggerfallUI.AddHUDText($"'OneButtonToggleHorse': '{keyName}' was not a valid KeyCode, falling back to '{toggleKey}'");
            }
            else
            {
                // Assigns the new key to toggle the mount
                toggleKey = newKeyCode;
            }
        }
    }
}
