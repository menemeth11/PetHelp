namespace PetHelp.Client.Nowy_folder;

public static class Utils
{
    /// <summary>
    ///  Returns formatted string of calculated age from <paramref name="_bDay"/> to today by default, <br /> 
    ///  or from <paramref name="_bDay"/> to any custom day passed in <paramref name="_day"/><br />
    /// </summary>
    /// <param name="_bDay">Day of Birthday</param>
    /// <param name="_day">Last day up to when Age will be calculated</param>
    ///  <returns>
    ///     if years > 1 then "1 rok 5 miesięcy" <br />
    ///     if years = 0 then "2 miesiące 20 dni"
    /// </returns>
    public static string GetFormattedAgeString(DateTime _bDay, DateTime _day = default)
    {
        if (_day == default) _day = DateTime.Now;

        int? rok_int = null, miesiac_int = null, dzien_int = null;
        string? rok_string = null, miesiac_string = null, dzien_string = null;
        var difference = _day - _bDay;
        DateTime age = new DateTime().Add(difference);

        if (age.Year - 1 > 0)
        {
            rok_int = age.Year - 1;
            rok_string = rok_int switch
            {
                1 => "rok",
                > 1 and < 5 => "lata",
                > 5 => "lat",
                _ => null
            };
        }

        if (age.Month - 1 > 0)
        {
            miesiac_int = age.Month - 1;
            miesiac_string = miesiac_int switch
            {
                1 => "miesiąc",
                > 1 and < 5 => "miesiące",
                > 5 => "miesięcy",
                _ => null
            };
        }

        if (age.Day - 1 > 0)
        {
            dzien_int = age.Day - 1;
            dzien_string = dzien_int switch
            {
                1 => "dzień",
                > 1 => "dni",
                _ => null
            };
        }
        string output = String.Empty;
        output += $"{(rok_int.HasValue ? rok_int : "")} {rok_string ?? ""} ";
        output += $"{(miesiac_int.HasValue ? miesiac_int : "")} {miesiac_string ?? ""} ";
        if (rok_int.HasValue == false)
            output += $"{(dzien_int.HasValue ? dzien_int : "")} {dzien_string ?? ""} ";

        return output;
    }
}
