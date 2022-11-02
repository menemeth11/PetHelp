using PetHelp.Shared.DTO;

namespace PetHelp.Client.Nowy_folder;

public class StateManager
{
    public int SelectedHodowlaId { get; set; } = 0;
    public List<ZwierzeDTO> Zwierzeta { get; set; } = new();
}
