using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using PetHelp.Shared.DTO;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PetHelp.Client.Pages;

public partial class Podglad_zwierzaczka : ComponentBase
{
    // Route parameter - distinguish what exactly Zwierze should we download from server by its key Id
    [Parameter] public string ZwierzeId { get; set; }
    // page loacl property for html binding and use in code
    public ZwierzeDTO zwierz { get; set; } = new();
    // property for keep track of current Zwierz state if its changed or no (used in undo-rever button)
    private bool IsChanged { get; set; } = false;
    private bool IsUpdated { get; set; } = false;
    // allow us to store response from server (allow to clone orginal-unchaged zwierze data, storing as a json format) populated on page initialisation
    private string _source_Json { get; set; }
    private bool _EditMode { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        // initial api call to our server to obtain ZwierzDTO data existing in database under Key corresponded to ZwierzeId
        var respond = await KlientHTTP.GetAsync($"Home/GetZwierzakDetails/{ZwierzeId}");
        // ensure if api call answer with succes code ( 200 OK )
        if (respond.IsSuccessStatusCode)
        {
            // store fetched full ZwierzDTO data into local property allows to render data inside html section
            zwierz = await respond.Content.ReadFromJsonAsync<ZwierzeDTO?>() ?? new();
            // store this respond in page local variableits allow us to fetch fresh 'unchaged' data
            // whenever its needed for example for reverting changes / undo button
            this._source_Json = await respond.Content.ReadAsStringAsync();
        }
    }

    private void BackToLiat()
    {
        // back to main page 'home'
        Navigation.NavigateTo("/Home");
    }

    private async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
        long maxFileSize = 5 * 1024 * 1024;
        var file = e.File;
        try
        {
            using var streamedContent = new StreamContent(file.OpenReadStream(maxFileSize));
            streamedContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out string contentType);

            zwierz.Zdjecie_Name = file.Name;
            zwierz.Zdjecie_Data = await streamedContent.ReadAsByteArrayAsync();
            zwierz.Zdjecie_MIME = contentType ?? "application/octet-stream";
        }
        catch (Exception ex)
        {
            Console.WriteLine("error upload file:" + ex.Message);
        }
    }
    private async Task Aktualizuj()
    {
        // find what index (if object exist, otherwise '-1') have current edited zwierzeDTO in cached list
        int index = _state.Zwierzeta.FindIndex(x => x.Id == zwierz.Id);
        //check if index (cached object type ZwierzDTO) exist in memory
        if (index > -1)
        {
            // overrite cached value with new edited one, its allow smooth rerender data
            //  and display info when use back to main page with his animals list,
            //  no additional page reload deeded
            _state.Zwierzeta[index] = zwierz;
        }
        // update zwierz data in database trough Post api call with updated data in body section
        await KlientHTTP.PostAsJsonAsync($"Home/AktualizujZwierze", zwierz);
        // data is changed, api is called, changed page state 'is changed' to true ( its turn ON undo button )
        IsChanged = true;
    }

    private async Task UndoChanges()
    {
        // deserialize orginal (unchanged) element and assign it again to page zwierz property
        this.zwierz = JsonConvert.DeserializeObject<ZwierzeDTO?>(_source_Json) ?? new();
        // find what index (if object exist, otherwise '-1') have current edited zwierzeDTO in cached list
        int index = _state.Zwierzeta.FindIndex(x => x.Id == zwierz.Id);
        //check if index (cached object type ZwierzDTO) exist in memory
        if (index > -1)
        {
            // overrite cached value with new edited one, its allow smooth rerender data
            //  and display info when use back to main page with his animals list,
            //  no additional page reload deeded
            _state.Zwierzeta[index] = zwierz;
        }
        // send to server old version to revert changes
        var result = await KlientHTTP.PostAsJsonAsync($"Home/AktualizujZwierze", zwierz);
        // change this page state 'is changed' to false, data back to orginal from before any modifications
        IsChanged = false;
    }

    private void SwitchEditModel()
    {
        _EditMode = !_EditMode;
    }
}
