using PetHelp.Shared.DTO;

namespace PetHelp.Client.States;

public class StateManager
{
    public int SelectedHodowlaId { get; set; } = -1;
    public List<ZwierzeDTO> Zwierzeta { get; set; } = new();
}
