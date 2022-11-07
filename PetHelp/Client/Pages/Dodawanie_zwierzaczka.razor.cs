using Microsoft.AspNetCore.Components;
using PetHelp.Shared.DTO;
using System.Net.Http.Json;

namespace PetHelp.Client.Pages;

public partial class Dodawanie_zwierzaczka : ComponentBase
{
    [Parameter] public string hodowlaID { get; set; }
    public ZwierzeDTO zwierz { get; set; } = new();
    public string CurrentUserId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
        this.CurrentUserId = authstate.User.Claims.First(x => x.Type == "sub").Value;
    }

    private void BackToLiat()
    {
        Navigation.NavigateTo("/Home");
    }

    public async Task CreateNew()
    {
        zwierz.WlascicielId = CurrentUserId;
        zwierz.HodowlaId = Convert.ToInt32(hodowlaID);

        var respond = await KlientHTTP.PostAsJsonAsync($"Home/DodajZwierze", zwierz);
        if (!respond.IsSuccessStatusCode)
        {
            Console.WriteLine("Niepowodzenie dodawania nowego zwierzaka");
            return;
        }

        ZwierzeDTO? newCreatedZwierz = await respond.Content.ReadFromJsonAsync<ZwierzeDTO>();
        if (newCreatedZwierz is null)
        {
            Console.WriteLine("niepowodzenie zapisywania zwierzaka, odebrano pusty obiekt");
            return;
        }
        // dodamy go do zcacheowanej naszej listy zwierzakow
        _state.Zwierzeta.Add(newCreatedZwierz);
        // przejdziemy do strony podglądu zwierzaka, z tego posiomu mozliwa bedzie tez jego edycja
        Navigation.NavigateTo($"/podglad/{newCreatedZwierz.Id}");
    }
}


