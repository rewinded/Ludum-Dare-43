﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class CrewMemberMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _pilotingText, _weightText, _strengthText, _intelligenceText;

    public TMP_Dropdown RoleDropdown;
    
    private CrewStats _stats;

    private bool _created;
    
    public void GiveStats(CrewStats stats)
    {
        _stats = stats;
        _pilotingText.text = $"Piloting: {_stats.Piloting}";
        _weightText.text = $"Weight: {_stats.Weight}";
        _strengthText.text = $"Strength: {_stats.Strength}";
        _intelligenceText.text = $"Intelligence: {_stats.Intelligence}";
        RoleDropdown.value = (int) _stats.Role;
    }

    public void Start()
    {
        _created = true;
    }
    
    public void Close()
    {
        MenuManager.Instance.MenuOpened = false;
        Destroy(gameObject);
    }

    public void RoleDropdownChanged()
    {
        if (!_created) return;
        
        var successfulRoleSwitch = _stats.SwitchRoles((CrewStats.MemberRole) RoleDropdown.value, false);
        if (!successfulRoleSwitch)
        {
            RoleDropdown.value = (int) _stats.Role;
        }
    }

}
